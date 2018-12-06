using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public static WaveManager Instance;

    public List<EnemyWave> enemyWaves = new List<EnemyWave>();
    private float elapsedTime = 0f;
    private EnemyWave activeWave;
    private float spawnCounter = 0f;
    private List<EnemyWave> activatedWaves = new List<EnemyWave>();

    // Use this for initialization
    void Awake ()
    {
        Instance = this;
	}

    void Update()
    {
        elapsedTime += Time.deltaTime;
        SearchForWave();
        UpdateActiveWave();
    }
    private void SearchForWave()
    {
        // Check For the incoming wave, add an enemy wave if none currently there. Update wave number and display start of wave screen
        foreach (EnemyWave enemyWave in enemyWaves)
        {
            //4
            if (!activatedWaves.Contains(enemyWave) && enemyWave.startSpawnTimeInSeconds <= elapsedTime)
            {
                //5
                activeWave = enemyWave;
                activatedWaves.Add(enemyWave);
                spawnCounter = 0f;
                GameManager.Instance.waveNumber++;
                // 
                UIManager.Instance.ShowCenterWindow("Wave " + GameManager.Instance.waveNumber);
                break;
            }
        }
    }
    //7
    private void UpdateActiveWave()
    {
        if (activeWave != null)
        {
            spawnCounter += Time.deltaTime;
            // If spawn counter is higher than active wave time enemy hasnt spawned
            if (spawnCounter >= activeWave.timeBetweenSpawnsInSeconds)
            {
                spawnCounter = 0f;
                if (activeWave.listOfEnemies.Count != 0)
                {
                    GameObject enemy = (GameObject)Instantiate(activeWave.listOfEnemies[0], WaypointManager.Instance.
                           GetSpawnPosition(activeWave.pathIndex), Quaternion.identity);
                    enemy.GetComponent<Enemy>().pathIndex = activeWave.pathIndex;
                    activeWave.listOfEnemies.RemoveAt(0);
                }
                else
                {
                    activeWave = null;
                    if (activatedWaves.Count == enemyWaves.Count)
                    {
                        GameManager.Instance.enemySpawningOver = true;
                        // All waves are over
                    }
                }
            }
        }
    }

    public void StopSpawning()
    {
        elapsedTime = 0;
        spawnCounter = 0;
        activeWave = null;
        activatedWaves.Clear();
        enabled = false;
    }
}

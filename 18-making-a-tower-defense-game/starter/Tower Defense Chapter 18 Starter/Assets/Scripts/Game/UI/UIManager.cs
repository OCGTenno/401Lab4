using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    
    public static UIManager Instance;
    
    public GameObject addTowerWindow;
    public GameObject towerInfoWindow;

    public Text txtGold;
    public Text txtWave;
    public Text txtEscapedEnemies;

    // Use this for initialization
    //1
    void Awake()
    {
        Instance = this;
    }
    //2
    private void UpdateTopBar()
    {
        txtGold.text = GameManager.Instance.gold.ToString();
        txtWave.text = "Wave " + GameManager.Instance.waveNumber + " / " +
        WaveManager.Instance.enemyWaves.Count;
        txtEscapedEnemies.text = "Escaped Enemies " +
        GameManager.Instance.escapedEnemies + " / " +
        GameManager.Instance.maxAllowedEscapedEnemies;
    }
    //3
    public void ShowAddTowerWindow(GameObject towerSlot)
    {
        addTowerWindow.SetActive(true);
        addTowerWindow.GetComponent<AddTowerWindow>().towerSlotToAddTowerTo = towerSlot;
        UtilityMethods.MoveUiElementToWorldPosition(addTowerWindow.GetComponent<RectTransform>(),
            towerSlot.transform.position);
    }

    // Update is called once per frame
    void Update () {
        UpdateTopBar();
    }

    public void ShowTowerInfoWindow(Tower tower)
    {
        towerInfoWindow.GetComponent<TowerInfoWindow>().tower = tower;
        towerInfoWindow.SetActive(true);
        UtilityMethods.MoveUiElementToWorldPosition(towerInfoWindow.
        GetComponent<RectTransform>(), tower.transform.position);
    }
}

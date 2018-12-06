﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    
    public static UIManager Instance;
    
    public GameObject addTowerWindow;       // White tower slot window 

    public GameObject towerInfoWindow;     

    public GameObject winGameWindow;        // Win lose windows plus background
    public GameObject loseGameWindow;
    public GameObject blackBackground;

    public GameObject centerWindow;         // Center for start of wave and Damage for enemy escaped
    public GameObject damageCanvas;

    public Text txtGold;
    public Text txtWave;
    public Text txtEscapedEnemies;

    public Transform enemyHealthBars;
    public GameObject enemyHealthBarPrefab;

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

    // References to the Windows and Background
    public void ShowWinScreen()
    {
        blackBackground.SetActive(true);
        winGameWindow.SetActive(true);
    }
    public void ShowLoseScreen()
    {
        blackBackground.SetActive(true);
        loseGameWindow.SetActive(true);
    }

    // Create the Health Bar above enemy and Child it to the object
    public void CreateHealthBarForEnemy(Enemy enemy)
    {
        GameObject healthBar = Instantiate(enemyHealthBarPrefab);
        healthBar.transform.SetParent(enemyHealthBars, false);
        healthBar.GetComponent<EnemyHealthBar>().enemy = enemy;
    }

    public void ShowCenterWindow(string text)
    {
        centerWindow.transform.Find("TxtWave").GetComponent<Text>().
        text = text;
        StartCoroutine(EnableAndDisableCenterWindow());
    }

    private IEnumerator EnableAndDisableCenterWindow()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.4f);
            centerWindow.SetActive(true);
            yield return new WaitForSeconds(.4f);
            centerWindow.SetActive(false);
        }
    }

    public void ShowDamage()
    {
        StartCoroutine(DoDamageAnimation());
    }

    private IEnumerator DoDamageAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.1f);
            damageCanvas.SetActive(true);
            yield return new WaitForSeconds(.1f);
            damageCanvas.SetActive(false);
        }
    }
}

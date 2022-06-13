﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public bool gameStarted;
    private bool popUpFlag;
    public GameObject joystic;
    public Button startButton;
    public Button settingButton;
    public GameObject popUp;
    public GameObject moneyCountUItext;
    public GameObject UpgradeUI;

    void Start()
    {
        popUpFlag = false;
        gameStarted = false;
        startButton.GetComponent<Button>().onClick.AddListener(clicked);
        settingButton.GetComponent<Button>().onClick.AddListener(clickedPopUp);
    }

    public void clicked()
    {
        gameStarted = true;
        joystic.gameObject.SetActive(true);
        Destroy(startButton.gameObject);
    }

    public void closeUIClicked()
    {
        UpgradeUI.gameObject.SetActive(false);
    }

    public void clickedPopUp()
    {
        if (popUpFlag)
        {
            popUp.gameObject.SetActive(false);
            popUpFlag = false;
            joystic.gameObject.SetActive(true);
        }
        else
        {
            popUp.gameObject.SetActive(true);
            popUpFlag = true;
            joystic.gameObject.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        if (((gameObject.GetComponent<GameManeger>().collectSize - 1) * 100) >= 1000)
        {
            moneyCountUItext.GetComponent<Text>().text ="$" + (((gameObject.GetComponent<GameManeger>().collectSize - 1) ) / 10).ToString() + "." + ((gameObject.GetComponent<GameManeger>().collectSize - 1) % 10).ToString() + "K";
        }
        else
        {
            
            moneyCountUItext.GetComponent<Text>().text = "$" + ((gameObject.GetComponent<GameManeger>().collectSize - 1) * 100).ToString();
        }
    }
    
    
    
    
}
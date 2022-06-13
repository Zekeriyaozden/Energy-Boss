using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpgradeArea : MonoBehaviour
{
    public GameObject upgradeUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            upgradeUI.SetActive(true);
            GameObject.Find("GameManeger").GetComponent<ButtonControl>().gameStarted = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("GameManeger").GetComponent<ButtonControl>().gameStarted = true;
            upgradeUI.SetActive(false);
        }
    }
}

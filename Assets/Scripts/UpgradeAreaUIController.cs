using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAreaUIController : MonoBehaviour
{
    public GameObject UI;
    public GameObject gObj;
    private bool flag;
    void Start()
    {
        flag = true;
    }
    void Update()
    {
        if (flag)
        {
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gObj = other.gameObject;
            flag = true;
            //gObj.GetComponent<PlayerController>().moneyCountPlayer;
            UI.gameObject.SetActive(true);
            
        }
    }
}

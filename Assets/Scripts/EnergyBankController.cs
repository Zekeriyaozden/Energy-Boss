﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBankController : MonoBehaviour
{
    public Transform parentObj;
    public float waitSeconds;
    public int moneyCount;
    public Vector3 target1;
    public Vector3 target2;
    public Vector3 target3;
    public GameObject referanceObj;
    public Vector3 tempObj1;
    public Vector3 tempObj2;
    public Vector3 tempObj3;
    public Vector3 tempPos1;
    public Vector3 tempPos2;
    public Vector3 thisPos;
    public float speed;
    public int collectSize;
    private float interpolate;
    private bool flag;
    void Start()
    {
        parentObj = gameObject.transform.GetChild(1);
        flag = true;
        StartCoroutine(moneySpawn());
    }

    IEnumerator moneySpawn()
    {

        while (flag)
        {
            yield return new WaitForSeconds(waitSeconds);
        if (flag)
        {
            if (moneyCount % 3 == 0)
            {
                GameObject gm = Instantiate(referanceObj, gameObject.transform.position, Quaternion.identity, parentObj);
                int num = parentObj.childCount / 3;
                gm.AddComponent<MoneySpawnController>();
                gm.GetComponent<MoneySpawnController>().target = gameObject.transform.position + new Vector3(-1.8f,0,-3.621f) + ((Vector3.up * 0.2f) * num);
                gm.GetComponent<MoneySpawnController>().tempObj = gm.GetComponent<MoneySpawnController>().target + new Vector3(0,5f,0);
                //gameObject.z-4
                //1 = gobj - 1.8
                //2 = gobj
                //3 = gobj + 1.8
            }
            else if (moneyCount % 3 == 1)
            {
                GameObject gm = Instantiate(referanceObj, gameObject.transform.position, Quaternion.identity, parentObj);
                int num = parentObj.childCount / 3;
                gm.AddComponent<MoneySpawnController>();
                gm.GetComponent<MoneySpawnController>().target = gameObject.transform.position + new Vector3(0,0,-3.621f) + ((Vector3.up * 0.2f) * num);
                gm.GetComponent<MoneySpawnController>().tempObj = gm.GetComponent<MoneySpawnController>().target + new Vector3(0,5f,0);
            }
            else if (moneyCount % 3 == 2)
            {
                GameObject gm = Instantiate(referanceObj, gameObject.transform.position, Quaternion.identity, parentObj);
                int num = (parentObj.childCount / 3) - 1;
                gm.AddComponent<MoneySpawnController>();
                gm.GetComponent<MoneySpawnController>().target = gameObject.transform.position + new Vector3(1.8f,0,-3.621f) + ((Vector3.up * 0.2f) * num);
                gm.GetComponent<MoneySpawnController>().tempObj = gm.GetComponent<MoneySpawnController>().target + new Vector3(0,5f,0);
            }
        }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyCount = parentObj.childCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            flag = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            flag = true;
            StartCoroutine(moneySpawn());
        }
    }
}

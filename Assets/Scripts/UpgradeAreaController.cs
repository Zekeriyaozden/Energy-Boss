using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAreaController : MonoBehaviour
{
    public int cost;
    public GameObject referanceObject;
    public GameObject particle;
    void Start()
    {
        cost = 300;
    }
    
    
    
    void Update()
    {
        if (cost <= 0)
        {
            Debug.Log(cost);
        } 
    }

}

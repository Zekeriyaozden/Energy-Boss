using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAreaController : MonoBehaviour
{
    public bool isEnter;
    void Start()
    {
        isEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //isEnter = true;
    }


    private void OnTriggerExit(Collider other)
    {
        //isEnter = false;
    }
}

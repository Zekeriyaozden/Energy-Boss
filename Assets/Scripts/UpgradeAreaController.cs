using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeAreaController : MonoBehaviour
{
    public int cost;
    public GameObject referanceObject;
    public GameObject particle;
    public GameObject energyItem;
    public float waitSeconds;
    private bool flag;
    void Start()
    {
        flag = true;
    }
    
    
    
    void Update()
    {
        referanceObject.GetComponent<Text>().text = cost + "$";
        if (cost == 0 && flag)
        {
            particleSpawn();
            flag = false;
        }
    }

    void particleSpawn()
    {
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(objectSpawn());
    }

    IEnumerator objectSpawn()
    {
        yield return new WaitForSeconds(waitSeconds);
        Instantiate(energyItem, gameObject.transform.position + new Vector3(-1.4f, 1.1f, -0.2f), Quaternion.identity);
        // x - 1.4
        // y + 1.1
        // z - 0.2
        Destroy(gameObject);
    }



}

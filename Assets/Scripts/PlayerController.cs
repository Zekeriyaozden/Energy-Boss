using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moneyPopSpeed;
    public bool stopCourotine;
    private Transform tm;
    public int moneyCountPlayer;
    public GameObject moneyParent;
    void Start()
    {
        stopCourotine = true;
    }

    // Update is called once per frame
    void Update()
    {
        moneyCountPlayer = moneyParent.transform.childCount - 1;
    }

    IEnumerator Upgrade()
    {
        while (stopCourotine == false)
        {
            if (tm.gameObject.GetComponent<UpgradeAreaController>().cost > 0 && GameObject.Find("GameManeger").GetComponent<GameManeger>().collectSize > 1)
            {
                yield return new WaitForSeconds(moneyPopSpeed);
                GameObject.Find("GameManeger").GetComponent<GameManeger>().MoneySpend(tm);
                tm.gameObject.GetComponent<UpgradeAreaController>().cost = tm.gameObject.GetComponent<UpgradeAreaController>().cost - 100;
                Debug.Log("-");
            }
            else
            {
                stopCourotine = true;
            }
            
        }
    }

/*
 *     private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<JoystickPlayerExample>().isIdle == true)
        {
            stopCourotine = false;
        }
    }
 */

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Upgrade")
        {
            tm = other.transform;
            stopCourotine = false;
            StartCoroutine("Upgrade");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Upgrade")
        {
            stopCourotine = true;
            StopCoroutine("Upgrade");
        }
    }
}

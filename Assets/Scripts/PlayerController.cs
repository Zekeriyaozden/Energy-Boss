using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moneyPopSpeed;
    public bool stopCourotine;
    private Transform tm;
    void Start()
    {
        stopCourotine = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Upgrade()
    {
        while (stopCourotine == false)
        {
            yield return new WaitForSeconds(moneyPopSpeed);
            GameObject.Find("GameManeger").GetComponent<GameManeger>().MoneySpend(tm);
        }

        Debug.Log("CourIsFinished!!");
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
        tm = other.transform;
        if (other.tag == "Upgrade")
        {
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

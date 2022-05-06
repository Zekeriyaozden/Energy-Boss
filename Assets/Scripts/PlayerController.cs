using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moneyPopSpeed;
    public bool stopCourotine;
    void Start()
    {
        stopCourotine = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<JoystickPlayerExample>().isMoving == true)
        {
            stopCourotine = true;
        }
    }

    IEnumerator Upgrade()
    {
        while (stopCourotine == false)
        {
            yield return new WaitForSeconds(moneyPopSpeed);
            Debug.Log("Waited");
        }

        Debug.Log("CourIsFinished!!");
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<JoystickPlayerExample>().isIdle == true)
        {
            stopCourotine = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Upgrade")
        {
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

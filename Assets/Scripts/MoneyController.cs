using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public GameObject upgradeUI;
    public Transform target;
    public float spendSpeed;
    private Vector3 tempPos1;
    private Vector3 tempPos2;
    private Vector3 tempObj;
    private float interpolate;
    private Vector3 moneyPos;
    void Start()
    {
        interpolate = 0;
        transform.SetParent(null);
        moneyPos = transform.position;
        tempObj = Vector3.Lerp(moneyPos, target.position, 0.5f);
        tempObj.y = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (interpolate <= 1)
        {
            interpolate += spendSpeed * Time.deltaTime;
            tempPos1 = Vector3.Lerp(moneyPos, tempObj, interpolate);
            tempPos2 = Vector3.Lerp(tempObj, target.position , interpolate);
            gameObject.transform.position = Vector3.Lerp(tempPos1, tempPos2, interpolate);
        }

        if (interpolate >= 1)
        {
            Destroy(gameObject);
        }
    }
}

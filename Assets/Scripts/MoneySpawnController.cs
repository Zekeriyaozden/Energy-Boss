using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawnController : MonoBehaviour
{
    public Vector3 target;
    public GameObject referanceObj;
    public Vector3 tempObj;
    public Vector3 tempPos1;
    public Vector3 tempPos2;
    public Vector3 thisPos;
    public float speed;
    private float interpolate;
    private bool flag;
    void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        thisPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (interpolate < 1)
        {
            interpolate += speed * Time.deltaTime;
            tempPos1 = Vector3.Lerp(thisPos, tempObj, interpolate);
            tempPos2 = Vector3.Lerp(tempObj, target , interpolate);
            gameObject.transform.position = Vector3.Lerp(tempPos1,tempPos2, interpolate);
        }
        
    }
}

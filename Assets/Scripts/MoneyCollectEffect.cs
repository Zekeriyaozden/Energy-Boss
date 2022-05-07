using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectEffect : MonoBehaviour
{
    public Vector3 target;
    public GameObject referanceObj;
    public Vector3 tempObj;
    public Vector3 tempPos1;
    public Vector3 tempPos2;
    public Vector3 thisPos;
    public float speed;
    public int collectSize;
    private float interpolate;
    private bool flag;
    
    void Start()
    {
        flag = true;
        speed = GameObject.Find("GameManeger").GetComponent<GameManeger>().collectSpeed;
        thisPos = gameObject.transform.position;
        tempObj = thisPos;
        tempObj.y = 4f;
        tempObj.x = thisPos.x - 4f;
        collectSize = GameObject.Find("GameManeger").GetComponent<GameManeger>().collectSize;
    }

    // Update is called once per frame
    void Update()
    {
        referanceObj = GameObject.Find("GameManeger").GetComponent<GameManeger>().referanceObj;
        if (interpolate < 1)
        {
            interpolate += speed * Time.deltaTime;
            target = referanceObj.transform.position + ((Vector3.up * 0.08f) * collectSize);
            gameObject.transform.rotation = referanceObj.transform.rotation;
            tempPos1 = Vector3.Lerp(thisPos,tempObj,interpolate);
            tempPos2 = Vector3.Lerp(tempObj, target, interpolate);
            gameObject.transform.position = Vector3.Lerp(tempPos1, tempPos2, interpolate);
        }

        else
        {
            if(flag)
            {
                Debug.Log(collectSize);
                gameObject.transform.position = referanceObj.transform.position + ((Vector3.up * 0.08f) * collectSize);
                flag = false;
            }
        }

        

        
    }
}

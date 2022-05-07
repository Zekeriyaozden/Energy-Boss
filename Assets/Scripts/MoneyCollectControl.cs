using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectControl : MonoBehaviour
{
    public GameObject gameManeger;
    public float size;
    public int collectSize;
    void Start()
    {
        collectSize = 0;
        gameManeger = GameObject.Find("GameManeger");
    }

    // Update is called once per frame
    void Update()
    {
        collectSize = gameManeger.GetComponent<GameManeger>().collectSize;

    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (collectSize >= 1)
            {
                gameManeger.GetComponent<GameManeger>().PushStack(this.gameObject);
                gameObject.transform.SetParent(gameManeger.GetComponent<GameManeger>().collectObj.transform);
                gameObject.transform.localScale = gameManeger.GetComponent<GameManeger>().referanceObj.transform.localScale;
                //gameObject.transform.position = ((Vector3.up * size) * collectSize) + gameManeger.GetComponent<GameManeger>().referanceObj.transform.position;
                gameObject.transform.rotation = gameManeger.GetComponent<GameManeger>().referanceObj.transform.rotation;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.AddComponent<MoneyCollectEffect>();
            }
        }
    }
}

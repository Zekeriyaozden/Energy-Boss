using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        StartCoroutine(collect(other.gameObject));
    }

    IEnumerator collect(GameObject gm)
    {
        float ret = Random.Range(0, 0.3f);
        yield return new WaitForSeconds(ret);
        if (gm.gameObject.tag == "Player")
        {
            if (collectSize >= 1)
            {
                if (gm.gameObject.GetComponent<PlayerController>().moneyCountPlayer >
                    GameObject.Find("GameManeger").GetComponent<GameManeger>().stackSizeMax)
                {
                    
                }
                else
                {
                    gameManeger.GetComponent<GameManeger>().PushStack(this.gameObject);
                    gameObject.transform.SetParent(gameManeger.GetComponent<GameManeger>().collectObj.transform);
                    gameObject.transform.rotation = gameManeger.GetComponent<GameManeger>().referanceObj.transform.rotation;
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    gameObject.AddComponent<MoneyCollectEffect>();
                }
               
            }
        }
    }
    
    
    
}

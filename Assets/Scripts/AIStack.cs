using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStack : MonoBehaviour
{
    public int stackSize;
    private bool playerOnArea;
    private float stackSpawnWait;
    void Start()
    {
        stackSpawnWait = GameObject.Find("GameManeger").GetComponent<GameManeger>().stackWait;
        playerOnArea = false;
        stackSize = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        stackSize = gameObject.transform.childCount;
    }
    
    IEnumerator moneyCollect()
    {
        int stackTemp = stackSize;
        while (stackTemp > 0 && playerOnArea && GameObject.Find("GameManeger").GetComponent<GameManeger>().stackSizeMax >
            (GameObject.Find("GameManeger").GetComponent<GameManeger>().collectSize - 1))
        {
            GameObject gm = gameObject.transform.GetChild(stackTemp-1).gameObject;
            GameObject.Find("GameManeger").GetComponent<GameManeger>().PushStack(gm);
            gm.transform.SetParent(GameObject.Find("GameManeger").GetComponent<GameManeger>().collectObj.transform);
            //gm.transform.rotation = GameObject.Find("GameManeger").GetComponent<GameManeger>().referanceObjAI.transform.rotation;
            gm.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(stackSpawnWait);
            gm.AddComponent<MoneyCollectEffect>();
            stackTemp--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnArea = true;
            StartCoroutine(moneyCollect());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnArea = false;
            StopCoroutine(moneyCollect());
        }
    }
}

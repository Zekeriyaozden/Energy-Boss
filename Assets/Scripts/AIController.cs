using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Stack<GameObject> moneyStack = new Stack<GameObject>();
    public GameObject referanceMoney;
    public float moneyPopSpeed;
    public bool onTrigger;
    private NavMeshAgent navMesh;
    public List<GameObject> objList = new List<GameObject>();
    private GameObject destObj;
    public int stackSize;
    private float stackSpawnWait;
    public List<GameObject> electric = new List<GameObject>();
    private GameObject destElect;
    public int maxStackSize;
    public float speed;
    public bool isWorking;
    public bool objDist;
    public GameObject tempElectricObj;
    void Start()
    {
        isWorking = false;
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.destination = electric[0].transform.GetChild(4).transform.position;
        objDist = true;
        stackSpawnWait = GameObject.Find("GameManeger").GetComponent<GameManeger>().stackWait;
    }

    void swapTarget(bool flag)
    {
        if (flag)
        {
            objDist = false;
            float temp = Vector3.Distance(gameObject.transform.position , electric[0].transform.position);
            int tempObj = 0;
            for (int i = 0; i < electric.Capacity; i++)
            {
                float dist = Vector3.Distance(gameObject.transform.position, electric[i].transform.position);
                if (dist < temp)
                {
                    temp = dist;
                    tempObj = i;
                }
            }

            navMesh.destination = electric[tempObj].gameObject.transform.position;

        }
        else
        {
            
            
        }
    }

    void findCloserElectric()
    {
        float temp = Vector3.Distance(gameObject.transform.position,
            electric[0].transform.position);
        int flag;
        flag = 0;
        
        for (int i = 0; i < electric.Count; i++)
        {
           // Debug.Log(electric[i].transform.GetChild(4).name + " -- name");
            if (temp > Vector3.Distance(gameObject.transform.position,
                electric[i].transform.position))
            {
                flag = i;
                temp = Vector3.Distance(gameObject.transform.position,
                    electric[i].transform.position);
            }
        }

        navMesh.destination = electric[flag].transform.position;
        if (Vector3.Distance(gameObject.transform.position, electric[flag].transform.position) < 2f)
        {
            
            if (stackSize == 0)
            {
                swapTarget(true);
            }
        }
    }

    IEnumerator toObjC()
    {
        while (true)
        {
            navMesh.destination = objList[0].gameObject.transform.position;
            if (stackSize > 0)
            {
                yield return new WaitForSeconds(moneyPopSpeed);
                Debug.Log("toObjC");
                MoneySpend(objList[0].gameObject.transform);
            }
            else
            {
                Debug.Log(stackSize + "stackSize");
                break;
            }
        }
        objDist = true;
    }
    
    private void toObj()
    {
        navMesh.destination = objList[0].gameObject.transform.position;
    }
    
    public void MoneySpend(Transform target)
    {
        if (stackSize > 0)
        {
            GameObject obj = moneyStack.Pop();
            obj.gameObject.transform.SetParent(null);
            obj.AddComponent<MoneyController>();
            obj.GetComponent<MoneyController>().target = target;
            obj.GetComponent<MoneyController>().spendSpeed = GameObject.Find("GameManeger").GetComponent<GameManeger>().spendSpeed;
        }
    }
    
    
    void Update()
    {
        stackSize = moneyStack.Count;
        if (objDist)
        {
            findCloserElectric();
        }

        if (!objDist)
        {
            toObj();
        }
    }
    
    IEnumerator moneyCollect(GameObject Area)
    {
        int stackTemp = Area.gameObject.transform.childCount;
        while (true)
        {
            stackTemp = Area.gameObject.transform.childCount;
            Debug.Log(Area.gameObject.transform.childCount);
            if (stackTemp > 0 && maxStackSize > stackSize)
            {
                GameObject gm = Area.transform.GetChild(stackTemp-1).gameObject;
                moneyStack.Push(gm);
                gm.transform.SetParent(gameObject.transform.GetChild(2));
                gm.transform.rotation = referanceMoney.gameObject.transform.rotation;
                gm.GetComponent<BoxCollider>().enabled = false;
                yield return new WaitForSeconds(stackSpawnWait);
                gm.AddComponent<MoneyCollectToAI>();
                gm.GetComponent<MoneyCollectToAI>().referanceObj = referanceMoney;
                gm.GetComponent<MoneyCollectToAI>().collectSize = stackSize;
            }
            else
            {
                yield return new WaitForSeconds(stackSpawnWait);
            }

            if (stackSize == maxStackSize)
            {
                objDist = false;
                break;
            }

        }
        if (stackSize == maxStackSize)
        {
            onTrigger = false;
            
        }
        
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "moneyParent")
        {
            StartCoroutine(moneyCollect(other.gameObject));
            onTrigger = true;
        }

        if (other.gameObject.tag == "Upgrade")
        {
            StartCoroutine(toObjC());
            onTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "moneyParent")
        {
            onTrigger = false;
        }

        if (other.gameObject.tag == "Upgrade")
        {
            onTrigger = false;
        }
    }
}

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
    private NavMeshAgent navMesh;
    public List<GameObject> objList = new List<GameObject>();
    private GameObject destObj;
    public int stackSize;
    private float stackSpawnWait;
    public List<GameObject> electric = new List<GameObject>();
    private GameObject destElect;
    public int maxStackSize;
    public bool atUpdate;
    public float speed;
    public bool isWorking;
    public bool objDist;
    public GameObject tempElectricObj;
    void Start()
    {
        atUpdate = false;
        isWorking = false;
        navMesh = gameObject.GetComponent<NavMeshAgent>();
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
/*
 *         if (Vector3.Distance(gameObject.transform.position, electric[flag].transform.position) < 2f)
        {
            
            if (stackSize == 0)
            {
                swapTarget(true);
            }
        }
 */
    }

    IEnumerator toObjC()
    {
        while (true)
        {
            
            navMesh.destination = objList[0].gameObject.transform.position;
            if (objList[0].gameObject.GetComponent<UpgradeAreaController>().cost == 0)
            {
                break;
            }
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
        if (stackSize > 0 && target.gameObject.GetComponent<UpgradeAreaController>().cost > 0 && atUpdate)
        {
            GameObject obj = moneyStack.Pop();
            obj.gameObject.transform.SetParent(null);
            obj.AddComponent<MoneyController>();
            obj.GetComponent<MoneyController>().target = target;
            obj.GetComponent<MoneyController>().spendSpeed = GameObject.Find("GameManeger").GetComponent<GameManeger>().spendSpeed;
            target.gameObject.GetComponent<UpgradeAreaController>().cost =
                target.gameObject.GetComponent<UpgradeAreaController>().cost - 100;
        }
    }
    
    
    void Update()
    {
        if (isWorking)
        {
            if (stackSize == 0)
            {
                //objDist = true;
            }
            gameObject.GetComponent<Animator>().SetBool("isWorking",true);

            if (Vector3.Distance(gameObject.GetComponent<NavMeshAgent>().destination, gameObject.transform.position) <
                1)
                {
                    gameObject.GetComponent<Animator>().SetBool("idle",true);
                    gameObject.GetComponent<Animator>().SetBool("run",false);
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("run",true);
                    gameObject.GetComponent<Animator>().SetBool("idle",false);
                }
            
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
                gm.transform.SetParent(null);
                Vector3 temp = gm.transform.position;

                gm.transform.position = temp;
                moneyStack.Push(gm);
                gm.transform.rotation = referanceMoney.gameObject.transform.rotation;
                gm.AddComponent<MoneyCollectToAI>();
                gm.GetComponent<MoneyCollectToAI>().referanceObj = referanceMoney;
                gm.GetComponent<MoneyCollectToAI>().collectSize = stackSize;
                gm.transform.SetParent(gameObject.transform.GetChild(2));
                yield return new WaitForSeconds(stackSpawnWait);
            }
            else
            {
                yield return new WaitForSeconds(stackSpawnWait);
                break;
            }

            
                
                if (stackSize == maxStackSize)
                {
                    break;
                }
                
            
        }
        objDist = false;
        Debug.Log("moneyCollect");

        
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "moneyParent")
        {
            Debug.Log("onTrigEnterMoneyParent");
            StartCoroutine(moneyCollect(other.gameObject));
        }

        if (other.gameObject.tag == "Upgrade")
        {
            atUpdate = true;
            Debug.Log("onTrigEnterUpdate");
            StartCoroutine(toObjC());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "moneyParent")
        {
            objDist = false;
        }

        if (other.gameObject.tag == "Upgrade")
        {
            atUpdate = false;
            objDist = true;
        }
    }
}

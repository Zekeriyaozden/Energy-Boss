using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManeger : MonoBehaviour
{
    public Stack<GameObject> moneyStack = new Stack<GameObject>();
    public int collectSize;
    public float wallTranslateSpeed;
    public float PlayerSpeed;
    public float moneySpawnSpeed;
    public int stackSizeMax;
    public float stackWait;
    [Range(0,350)] public int playerMaxStack; 
    [Range(0,5)]
    public float collectSpeed;
    public GameObject collectObj;
    public GameObject referanceObj;
    public Transform startTransform;
    public float spendSpeed;
    void Start()
    {
        collectSize = 0;
    }
    void Update()
    {
        collectSize = collectObj.transform.childCount;

    }
    



    public void MoneySpend(Transform target)
    {
        if (collectSize > 1)
        {
            GameObject obj = PopStack();
            obj.gameObject.transform.SetParent(null);
            obj.AddComponent<MoneyController>();
            obj.GetComponent<MoneyController>().target = target;
            obj.GetComponent<MoneyController>().spendSpeed = spendSpeed;
        }

    }


    public void moneySpendUI(int price)
    {
        
    }
    public void stackUpdateUI(int max)
    {
        stackSizeMax = stackSizeMax + max;
    }

    public GameObject PopStack()
    {
        if (moneyStack.Count != 0)
        {
            return moneyStack.Pop();   
        }
        else
        {
            return gameObject;
        }
    }

    public void PushStack(GameObject money)
    {
        moneyStack.Push(money);
    }
    
}

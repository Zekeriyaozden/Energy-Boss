using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public Stack<GameObject> moneyStack = new Stack<GameObject>();
    public int collectSize;
    public GameObject collectObj;
    public GameObject objTemp;
    void Start()
    {
        collectSize = 0;
        
    }
    void Update()
    {
        collectSize = collectObj.transform.childCount;
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
        Debug.Log("Pusshing " + money.name);
        moneyStack.Push(money);
    }
    
}

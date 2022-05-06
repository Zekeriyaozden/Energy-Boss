using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public Stack<GameObject> moneyStack = new Stack<GameObject>();
    public int collectSize;
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
        GameObject obj = PopStack();
        obj.transform.SetParent(null);
        Vector3 moneyPos = obj.transform.position;
        float fl = 0;
        while (fl <= 1)
        {
            obj.transform.position = Vector3.Lerp(moneyPos, target.position, fl);
            fl += spendSpeed * Time.deltaTime;
        }
        
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

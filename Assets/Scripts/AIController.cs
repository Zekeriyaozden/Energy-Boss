using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private NavMeshAgent navMesh;
    public List<GameObject> objList = new List<GameObject>();
    private GameObject destObj;
    public int stackSize;
    public List<GameObject> electric = new List<GameObject>();
    private GameObject destElect;
    public int maxStackSize;
    public float speed;
    public bool isWorking;
    private bool objDist;
    void Start()
    {
        isWorking = false;
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.destination = electric[0].transform.GetChild(4).transform.position;
        objDist = true;
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
    
    void Update()
    {
        //Debug.Log(Vector3.Distance(gameObject.transform.position , objList[0].gameObject.transform.position));
        //distance<2;
        if (Vector3.Distance(gameObject.transform.position, objList[0].gameObject.transform.position) < 2f)
        {
            if (stackSize == 0)
            {
                if (objDist)
                {
                    swapTarget(true);
                }
            }
        }
        if (objDist)
        {
            for (int i = 0; i < objList.Capacity; i++)
            {
                Debug.Log(objList.Capacity);
                //navMesh.destination = objList[0].gameObject.transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private NavMeshAgent navMesh;
    public List<GameObject> objList = new List<GameObject>();
    public int maxStackSize;
    public float speed;
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        for (int i = 0; i < objList.Capacity; i++)
        {
            if (objList[i].gameObject != null)
            {
                navMesh.destination = objList[i].gameObject.transform.position;
            }
        }
        //navMesh.destination = gameObj.transform.position;
    }
}

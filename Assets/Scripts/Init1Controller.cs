using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Init1Controller : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            g2.gameObject.SetActive(true);
            Destroy(g1);
        }
    }
}

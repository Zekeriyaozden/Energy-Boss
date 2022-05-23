using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 distance;
    public bool s1;
    private bool s1Flag;
    private float s1D;
    public bool s2;
    private bool s2Flag;
    private float s2D;
    public float speed;
    void Start()
    {
        s1D = 0.00001f;
        s2D = 0.00001f;
        s1Flag = false;
        s2Flag = false;
        s1 = false;
        s2 = false;
        distance = Player.transform.position - gameObject.transform.position;
    }

    public void f1()
    {
        
    }

    public void f2()
    {
        
    }

    void LateUpdate()
    {
        
        if (s1)
        {
            if (!s1Flag)
            {
                s1D += Time.deltaTime * speed; 
            }
            else
            {
                s1D -= Time.deltaTime * speed; 
            }
            gameObject.transform.position = Vector3.Lerp(Player.transform.position - distance , new Vector3(87.4f,30f,41.76f),s1D);
            if (s1D >= 1)
            {
                s1Flag = true;
            }

            if (s1D <= 0)
            {
                s1 = false;
            }
        }

        if (s2)
        {
            if (!s2Flag)
            {
                s2D += Time.deltaTime * speed; 
            }
            else
            {
                s2D -= Time.deltaTime * speed; 
            }
            gameObject.transform.position = Vector3.Lerp(Player.transform.position - distance , new Vector3(68.56f,70.19f,-11.38f),s2D);
            if (s2D >= 1)
            {
                s2Flag = true;
            }

            if (s2D <= 0)
            {
                s2 = false;
            }
        }
        
        if (!s1 && !s2)
        {
            gameObject.transform.position = Player.transform.position - distance;
        }
    }
}

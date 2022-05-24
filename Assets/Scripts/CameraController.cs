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
    public bool s3;
    private bool s3Flag;
    private float s3D;
    public bool s4;
    private bool s4Flag;
    private float s4D;
    public float speed;
    void Start()
    {
        s1D = 0.00001f;
        s2D = 0.00001f;
        s3D = 0.00001f;
        s4D = 0.00001f;
        s1Flag = false;
        s2Flag = false;
        s3Flag = false;
        s4Flag = false;
        s1 = false;
        s2 = false;
        s3 = false;
        s4 = false;
        distance = Player.transform.position - gameObject.transform.position;
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
        
        if (s3)
        {
            Debug.Log("enter");
            if (!s3Flag)
            {
                s3D += Time.deltaTime * speed; 
            }
            else
            {
                s3D -= Time.deltaTime * speed; 
            }
            gameObject.transform.position = Vector3.Lerp(Player.transform.position - distance , new Vector3(5.2f,29.6f,-1.1f),s3D);
            if (s3D >= 1)
            {
                s3Flag = true;
            }

            if (s3D <= 0)
            {
                s3 = false;
            }
        }
        
        if (s4)
        {
            if (!s4Flag)
            {
                s4D += Time.deltaTime * speed; 
            }
            else
            {
                s4D -= Time.deltaTime * speed; 
            }
            gameObject.transform.position = Vector3.Lerp(Player.transform.position - distance , new Vector3(19.36f,67.15f,-9.08f),s4D);
            if (s4D >= 1)
            {
                s4Flag = true;
            }

            if (s4D <= 0)
            {
                s4 = false;
            }
        }
        
        
        
        if (!s1 && !s2 && !s3 && !s4)
        {
            gameObject.transform.position = Player.transform.position - distance;
        }
    }
}

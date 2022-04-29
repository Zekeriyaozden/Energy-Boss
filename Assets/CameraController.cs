using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 distance;
    void Start()
    {
        distance = Player.transform.position - gameObject.transform.position;
    }

    void LateUpdate()
    {
        gameObject.transform.position = Player.transform.position - distance;
    }
}

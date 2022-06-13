﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    private float speed;
    public Vector3 direction;
    public DynamicJoystick variableJoystick;
    private bool withMoney;
    public bool isMoving;
    public bool isIdle;
    public bool isMovingWItem;
    public bool isPlayerLifting;
    public bool isPlayerIdleWItem;

    public void Start()
    {
        withMoney = false;
        speed = GameObject.Find("GameManeger").GetComponent<GameManeger>().PlayerSpeed;
        isMoving = false;
        isIdle = true;
    }

    public void FixedUpdate()
    {
        if (GameObject.Find("GameManeger").GetComponent<GameManeger>().collectSize > 1)
        {
            withMoney = true;
        }
        else
        {
            withMoney = false;
        }
        speed = GameObject.Find("GameManeger").GetComponent<GameManeger>().PlayerSpeed;
        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        isPlayerMoving();
        animControl();
    }

    private void playerMechanic()
    {
        isMoving = true;
        gameObject.transform.Translate(direction * speed * Time.deltaTime , Space.World);
        gameObject.transform.LookAt(gameObject.transform.position + direction);
    }
    private bool isPlayerMoving()
    {
        if (direction.magnitude > 0)
        {
            playerMechanic();
            isPlayerIdleWItem = false;
            isIdle = false;
            if (isPlayerLifting)
            {
                isMovingWItem = true;
                isMoving = false;
                return true;
            }
            else
            {
                isMovingWItem = false;
                isMoving = true;
                return true;
            }
        }
        else
        {
            isMovingWItem = false;
            isMoving = false;
            if (isPlayerLifting)
            {
                isIdle = false;
                isPlayerIdleWItem = true;
                return false;
            }
            else
            {
                isIdle = true;
                isPlayerIdleWItem = false;
                return false;
            }
        }
    }

    private void animControl()
    {

        if (withMoney)
        {
            if (isIdle)
            {
                gameObject.GetComponent<Animator>().SetBool("IdleWLift",true);
                gameObject.GetComponent<Animator>().SetBool("Idle",false);
                gameObject.GetComponent<Animator>().SetBool("WalkingWithoutLift",false);
                gameObject.GetComponent<Animator>().SetBool("WalkingWLift",false);
            }else if (isMoving)
            {
                gameObject.GetComponent<Animator>().SetBool("WalkingWLift",true);
                gameObject.GetComponent<Animator>().SetBool("Idle",false);
                gameObject.GetComponent<Animator>().SetBool("WalkingWithoutLift",false);
                gameObject.GetComponent<Animator>().SetBool("IdleWLift",false);
            }
        }
        else
        {
            if (isIdle)
            {
                gameObject.GetComponent<Animator>().SetBool("Idle",true);
                gameObject.GetComponent<Animator>().SetBool("WalkingWithoutLift",false);
                gameObject.GetComponent<Animator>().SetBool("IdleWLift",false);
                gameObject.GetComponent<Animator>().SetBool("WalkingWLift",false);
                
            }else if (isMoving)
            {
                gameObject.GetComponent<Animator>().SetBool("WalkingWithoutLift",true);
                gameObject.GetComponent<Animator>().SetBool("Idle",false);
                gameObject.GetComponent<Animator>().SetBool("IdleWLift",false);
                gameObject.GetComponent<Animator>().SetBool("WalkingWLift",false);
            }
        }

    }
    

    
}
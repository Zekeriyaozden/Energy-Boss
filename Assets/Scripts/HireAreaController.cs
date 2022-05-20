using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HireAreaController : MonoBehaviour
{
    public GameObject AI;
    public GameObject UI;
    public int Price;
    private GameObject money;
    private GameObject gameManeger;
    
    
    void Start()
    {
        UI.gameObject.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text =
            (Price).ToString() + "$";
        gameManeger = GameObject.Find("GameManeger");
    }


    public void onClick()
    {
        AI.gameObject.GetComponent<AIController>().isWorking = true;
        for (int i = 0; i < Price / 100; i++)
        {
            money = gameManeger.GetComponent<GameManeger>().PopStack();
            Destroy(money.gameObject);
        }
        Destroy(UI.gameObject);
        Destroy(gameObject.GetComponent<Collider>());
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("GameManeger").GetComponent<GameManeger>().collectSize - 1) * 100 < Price)
        {
            UI.gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<Button>().interactable = false;
        }
        else
        {
            UI.gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<Button>().interactable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(false);
        }
    }
}

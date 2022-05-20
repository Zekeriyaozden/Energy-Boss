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
    
    void Start()
    {
        UI.gameObject.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text =
            Price.ToString() + "$";
    }


    public void onClick()
    {
        AI.gameObject.GetComponent<AIController>().isWorking = true;
        Destroy(UI.gameObject);
        Destroy(gameObject.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManeger").GetComponent<GameManeger>().collectSize * 100 < Price)
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

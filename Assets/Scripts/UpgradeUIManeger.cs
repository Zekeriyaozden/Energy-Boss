using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIManeger : MonoBehaviour
{
    public Button stackButton;
    public Button speedButton;
    public GameObject stackButtonText;
    public GameObject speedButtonText;
    public List<int> stackList;
    public List<int> speedList;
    private int tempSpeed;
    private int speedFlag;
    private int tempStack;
    private int stackFlag;
    void Start()
    {
        speedFlag = 0;
        stackFlag = 0;
        tempStack = stackList[stackFlag];
        tempSpeed = speedList[speedFlag];
    }
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (tempStack < ((gameObject.GetComponent<GameManeger>().collectSize - 1) * 100))
        {
            stackButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            stackButton.GetComponent<Button>().interactable = false;
        }

        if (tempSpeed < ((gameObject.GetComponent<GameManeger>().collectSize - 1) * 100))
        {
            speedButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            speedButton.GetComponent<Button>().interactable = false;
        }

    }
}

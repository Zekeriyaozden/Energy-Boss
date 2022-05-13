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
    public float speedIncrease;
    public int stackIncrease;
    void Start()
    {
        speedFlag = 0;
        stackFlag = 0;
        tempStack = stackList[stackFlag];
        tempSpeed = speedList[speedFlag];
        stackButtonText.gameObject.GetComponent<Text>().text = tempStack.ToString() + "$";
        speedButtonText.gameObject.GetComponent<Text>().text = tempSpeed.ToString() + "$";
    }




    void spendForStack()
    {
        if(stackList.Count> (stackFlag + 1))
        {
            for (int i = 0; i < (tempStack / 100); i++)
            {
                GameObject money = gameObject.GetComponent<GameManeger>().PopStack();
                Destroy(money.gameObject);
            }
            gameObject.GetComponent<GameManeger>().stackSizeMax = gameObject.GetComponent<GameManeger>().stackSizeMax + stackIncrease;
            stackFlag++;
            tempStack = stackList[stackFlag];
        }
    }

    void spendForSpeed()
    {
        if(speedList.Count> (speedFlag + 1))
        {
            Debug.Log(gameObject.GetComponent<GameManeger>().collectSize);
            for (int i = 0; i < (tempSpeed / 100); i++)
            {
                GameObject money = gameObject.GetComponent<GameManeger>().PopStack();
                Destroy(money.gameObject);
            }
            gameObject.GetComponent<GameManeger>().PlayerSpeed += speedIncrease; 
            speedFlag++;
            tempSpeed = speedList[speedFlag];
        }
    }
    
    
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

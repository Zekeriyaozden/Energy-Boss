using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeAreaController : MonoBehaviour
{
    private GameObject wall;
    public int cost;
    public int costTemp;
    public GameObject referanceObject;
    public GameObject particle;
    public GameObject energyItem;
    public float waitSeconds;
    public bool isWall;
    private bool flag;
    private float size;
    public GameObject image;
    private bool flagWall;
    private GameObject AIPlayer;
    void Start()
    {
        size = 1f;
        costTemp = cost;
        flag = true;
        flagWall = false;
        AIPlayer = GameObject.Find("AI Character");
    }
    
    
    
    void Update()
    {
        size = (float.Parse(costTemp.ToString()) - float.Parse(cost.ToString())) / float.Parse(costTemp.ToString());
        image.GetComponent<Image>().fillAmount = (1f - size);
        if (flagWall)
        {
            Destroy(energyItem.gameObject);
        }
        
        if (isWall)
        {
            if (cost == 0 && flag)
            {
                flag = false;
                StartCoroutine(wallTrans());
            }
        }

        if (cost >= 1000)
        {
            referanceObject.GetComponent<Text>().text = "$" + (cost / 1000).ToString() + "." + ((cost % 1000)/100).ToString() + "K";
        }
        else
        {
            referanceObject.GetComponent<Text>().text ="$" + cost.ToString();   
        }
        if (!isWall && cost == 0 && flag )
        {
            particleSpawn();
            flag = false;
        }
    }

    IEnumerator wallTrans()
    {
        yield return new WaitForSeconds(.5f);
        flagWall = true;
    }

    void particleSpawn()
    {
        GameObject gm = Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        gm.transform.position += new Vector3(0, 0, -2f);
        StartCoroutine(objectSpawn());
    }

    IEnumerator objectSpawn()
    {
        yield return new WaitForSeconds(waitSeconds);
        GameObject gm = Instantiate(energyItem, gameObject.transform.position + new Vector3(-1.4f, 0.45f, -0.2f), Quaternion.identity);
        gm.tag = "Untagged";
        GameObject.Find("GameManeger").GetComponent<GameManeger>().countLock++;
        AIPlayer.GetComponent<AIController>().electric.Add(gm.gameObject.transform.GetChild(4).gameObject);
        gm.transform.eulerAngles = new Vector3(0, 180, 0);
        // x - 1.4
        // y + 1.1
        // z - 0.2
        AIPlayer.GetComponent<AIController>().objList.Remove(gameObject);
        Destroy(gameObject);
    }



}

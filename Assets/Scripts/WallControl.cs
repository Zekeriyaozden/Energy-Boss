using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    private GameObject gameManeger;
    public int count;
    void Start()
    {
        gameManeger = GameObject.Find("GameManeger");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManeger.GetComponent<GameManeger>().countLock >= count)
        {
            Destroy(gameObject);
        }
    }
}

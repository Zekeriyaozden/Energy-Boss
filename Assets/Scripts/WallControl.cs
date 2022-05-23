using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    private GameObject gameManeger;
    public int count;
    public GameObject Fog;
    public GameObject cam;
    void Start()
    {
        gameManeger = GameObject.Find("GameManeger");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManeger.GetComponent<GameManeger>().countLock >= count)
        {
            if (count == 3)
            {
                cam.GetComponent<CameraController>().s2 = true;
            }
            Destroy(Fog);
            Destroy(gameObject);
        }
    }
}

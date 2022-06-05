using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogControl : MonoBehaviour
{
    private float price;
    public GameObject cam;
    public GameObject fog;
    void Start()
    {
        price = gameObject.GetComponent<UpgradeAreaController>().cost;
    }

    // Update is called once per frame
    void Update()
    {
        price = gameObject.GetComponent<UpgradeAreaController>().cost;
        if (price == 0)
        {
            cam.GetComponent<CameraController>().s1 = true;
            Destroy(fog);
        }
    }
}

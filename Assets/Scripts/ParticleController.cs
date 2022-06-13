using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(particleLifeTime());
    }

    IEnumerator particleLifeTime()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}

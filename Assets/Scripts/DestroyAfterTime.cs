using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time = 3.5f;
    void Start()
    {
        StartCoroutine(DestroyAfterTimee());
    }

    IEnumerator DestroyAfterTimee()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    // Update is called once per frame
    
}

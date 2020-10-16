using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public GameObject alarm;
    public bool up;
    public bool cd = true;
    void Start()
    {
        up = gameObject.GetComponent<Shoot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && cd)
        {
            cd = false;
            StartCoroutine(coold());
            alarm.gameObject.SetActive(true);
            Shoot.main.isUpgraded = true;
            StartCoroutine(activeTime());
        }
        
        
    }
    IEnumerator activeTime()
    {
        yield return new WaitForSeconds(5);
        alarm.gameObject.SetActive(false);
        Shoot.main.isUpgraded = false;
    }    
    IEnumerator coold()
    {
        yield return new WaitForSeconds(7);
        cd = true;
    }
}

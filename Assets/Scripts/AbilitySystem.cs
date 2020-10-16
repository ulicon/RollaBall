using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ability1;
    public GameObject ability2;
    public GameObject abilityCast1;
    public GameObject abilityCast2;
    public Text cd1, cd2;
    bool ab1ghost = false;
    bool failsafe1 = false;
    bool ab2ghost = false;
    bool failsafe2 = false;
    bool ab1ready = true, ab2ready = true;
    public int abilityCastDuration1;
    public int abilityCastDuration2;
    public int abilityCooldown1, abilityCooldown2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
    }
    void Ability1()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!ab1ghost && !failsafe1 && ab1ready)
            {
                GetComponent<Shoot>().enabled = false;
                failsafe1 = true;
                abilityCast1.gameObject.SetActive(true);
                ab1ghost = true;
                StartCoroutine(FailSafe1());
            }
            if (ab1ghost && !failsafe1)
            {
                GetComponent<Shoot>().enabled = true;
                failsafe1 = true;
                abilityCast1.gameObject.SetActive(false);
                ab1ghost = false;
                StartCoroutine(FailSafe1());
            }
        }
        if (Input.GetMouseButtonDown(0) && ab1ghost)
        {
            GetComponent<Shoot>().enabled = true;
            failsafe1 = true;
            StartCoroutine(AbilityCastDuration1());

        }
        if (Input.mouseScrollDelta.y > 0 && ab1ghost)
        {
            abilityCast1.transform.position += transform.forward * 100 * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0 && ab1ghost)
        {
            abilityCast1.transform.position -= transform.forward * 100 * Time.deltaTime;
        }
    }
    void Ability2()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!ab2ghost && !failsafe2 && ab2ready)
            {
                GetComponent<Shoot>().enabled = false;
                failsafe2 = true;
                abilityCast2.gameObject.SetActive(true);
                ab2ghost = true;
                StartCoroutine(FailSafe2());
            }
            if (ab2ghost && !failsafe2)
            {
                GetComponent<Shoot>().enabled = true;
                failsafe2 = true;
                abilityCast2.gameObject.SetActive(false);
                ab2ghost = false;
                StartCoroutine(FailSafe2());
            }
        }
        if (Input.GetMouseButtonDown(0) && ab2ghost)
        {
            GetComponent<Shoot>().enabled = true;
            failsafe2 = true;
            StartCoroutine(AbilityCastDuration2());
        }
        if (Input.mouseScrollDelta.y > 0 && ab2ghost)
        {
            abilityCast2.transform.position += transform.forward * 100 * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0 && ab2ghost)
        {
            abilityCast2.transform.position -= transform.forward * 100 * Time.deltaTime;
        }
    }
    IEnumerator FailSafe1()
    {
        yield return new WaitForSeconds(0.25f);
        failsafe1 = false;
    }
    IEnumerator FailSafe2()
    {
        yield return new WaitForSeconds(0.25f);
        failsafe2 = false;
    }
    IEnumerator AbilityCastDuration1()
    {
        yield return new WaitForSeconds(abilityCastDuration1);
        abilityCast1.gameObject.SetActive(false);
        Instantiate(ability1, abilityCast1.transform.position, abilityCast1.transform.rotation);
        StartCoroutine(AbilityCooldown1());
        ab1ghost = false;
        yield return new WaitForSeconds(0.25f);
        failsafe1 = false;
    }
    IEnumerator AbilityCastDuration2()
    {
        yield return new WaitForSeconds(abilityCastDuration2);
        abilityCast2.gameObject.SetActive(false);
        Instantiate(ability2, abilityCast2.transform.position, abilityCast2.transform.rotation);
        
        ab2ghost = false;
        yield return new WaitForSeconds(0.25f);
        failsafe2 = false;
    }
    IEnumerator AbilityCooldown1()
    {
        ab1ready = false;
        yield return new WaitForSeconds(abilityCooldown1);
        ab1ready = true;
    }
}

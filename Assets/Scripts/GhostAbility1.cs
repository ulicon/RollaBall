using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAbility1 : MonoBehaviour
{

    public GameObject Ability1;
    public GameObject Ability2;
    private void Awake()
    {
        GameObject ab1 = Ability1;
        GameObject ab2 = Ability2;
    }
    void Start()
    {
       
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Ability1, transform.position, transform.rotation);
            Debug.Log("dsaga");
        }
        
        if (Input.mouseScrollDelta.y > 0)
        {

            
            transform.position += transform.forward * 60 * Time.deltaTime;
            
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            
            transform.position -= transform.forward * 60 * Time.deltaTime;
           
        }
        

    }
    
}

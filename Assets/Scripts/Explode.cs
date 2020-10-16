using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effect;
    //public GameObject explodeSound;
    public float radius = 5f;
    public float damage = 25;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effect, transform.position, transform.rotation);
        //Instantiate(explodeSound, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Destructible"))
            {
                colliders[i].GetComponent<Health>().TakeDamage(damage);
                
            }
           
        }
        Destroy(gameObject);
    }
}

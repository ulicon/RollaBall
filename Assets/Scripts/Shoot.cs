using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float force = 40;
    public float firerate;
    float newFirerate;
    public bool isUpgraded = false;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public GameObject shootSound;
    public GameObject upgradedCanvas;
    public static Shoot main;
    private void Awake()
    {
        main = this;
    }
    void Update()
    {
        newFirerate = firerate * 2;
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            if (isUpgraded)
            {
                
                nextTimeToFire = Time.time + 1f / newFirerate;
                ThrowGrenade();
            }
            else
            {
                
                nextTimeToFire = Time.time + 1f / firerate;
                ThrowGrenade();
            }
            
            
        }
        if (isUpgraded)
        {
            upgradedCanvas.gameObject.SetActive(true);
        }
        if (!isUpgraded)
        {
            upgradedCanvas.gameObject.SetActive(false);
        }
    }

    void ThrowGrenade()
    {

        Instantiate(shootSound, transform.position, transform.rotation);
        GameObject grenade = Instantiate(projectile, transform.position + transform.forward * +1, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * force, ForceMode.VelocityChange);

    }
    
}

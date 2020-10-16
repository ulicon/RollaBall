using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 500;
    public float maxHealth = 500;
    public Slider slider;

    public GameObject deathParticle;
    //public GameObject deathSound;

    private void Start()
    {
        health = maxHealth;
        slider.value = calculateHealth();
    }

    private void Update()
    {
        slider.value = calculateHealth();

        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Instantiate(deathParticle, transform.position, transform.rotation);
            //Instantiate(deathSound, transform.position, transform.rotation);
            Die();
        }

        void Die()
        {


            Destroy(gameObject);


        }

    }
    float calculateHealth()
    {
        return health / maxHealth;
    }
}

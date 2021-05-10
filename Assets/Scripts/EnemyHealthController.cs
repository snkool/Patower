using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField] public float projectileDmg;

    void Start()
    {
        health = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Projectile"))
        {      
            health -= projectileDmg;
            if(health <= 0f)
            {
                Destroy(gameObject);
                
            }
            Destroy(other.gameObject);
        }
    }
}



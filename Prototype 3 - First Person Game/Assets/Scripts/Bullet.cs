using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    void OnEnable()
    {
        shootTime = Time.time;
    }

    void OntriggerEnter(Collider other)
    {
        // If hit deal out damage to the player
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        // If hit deal out damage to the enemy
        else if(other.CompareTag("Enemy"))
            other.GetComponent<EnemyAI>().TakeDamage(damage);
        // Disable Projectile for future use 
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}

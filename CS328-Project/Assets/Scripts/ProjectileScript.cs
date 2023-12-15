using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy with the specified tag
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component (assuming the enemy has this script)
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // Check if the enemy has the health component
            if (enemyHealth != null)
            {
                // Apply damage to the enemy
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the projectile on impact with an enemy
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public int numberOfProjectiles = 8;

    void Start()
    {
        // Invoke the method to shoot projectiles after a delay (e.g., 2 seconds)
        InvokeRepeating("ShootProjectiles", 2f, 2f);
    }

    void ShootProjectiles()
    {
        float angleStep = 360f / numberOfProjectiles;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // Create a projectile at the enemy's position
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Set the projectile's direction and speed
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }
}


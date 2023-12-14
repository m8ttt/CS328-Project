using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyAttack : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public float shootingRange = 5f;
    public float projectileSpeed = 5f;
    public float timeBetweenShots = 2f;

    private float elapsedTimeSinceLastShot = 0f;

    void Update()
    {
        // Check the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the player is within shooting range
        if (distanceToPlayer <= shootingRange)
        {
            // Shoot at the player
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer()
    {
        // Check if enough time has passed since the last shot
        if (Time.time - elapsedTimeSinceLastShot > timeBetweenShots)
        {
            // Create a projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Calculate the direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Set the projectile's velocity
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

            // Update the last shot time
            elapsedTimeSinceLastShot = Time.time;
        }
    }
}

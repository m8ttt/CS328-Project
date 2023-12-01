using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFall : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnInterval = 1f;
    public float spawnRadius = 25f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnProjectile();
            timer = 0f;
        }
    }

    void SpawnProjectile()
    {
        // Calculate a random angle
        float randomAngle = Random.Range(0f, 360f);

        // Convert the angle to radians
        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        // Calculate the spawn position based on the angle and radius
        Vector2 spawnPosition = new Vector2(
            transform.position.x + spawnRadius * Mathf.Cos(angleInRadians),
            transform.position.y + spawnRadius * Mathf.Sin(angleInRadians)
        );

        // Instantiate the projectile at the calculated position
        Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
    }

}

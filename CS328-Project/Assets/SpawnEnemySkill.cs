using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySkill : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust the speed as needed.
    public float spawnInterval = 5f;  // Time between spawns.
    public float detectionRange = 10f;  // Range within which the enemy detects the player.
    public GameObject enemyPrefab;  // Reference to the enemy prefab to be spawned.

    private Transform player;
    private float timeSinceLastSpawn = 0f;
    private bool isStandingStill = false;
    private float standStillDuration = 2f;
    private float spawnOffset = 1.5f;  // Adjust the offset as needed.
    private bool playerInRange = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the "Player" tag.
    }

    void Update()
    {
        if (player != null)
        {
            // Check if the player is within the detection range.
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            playerInRange = distanceToPlayer <= detectionRange;

            if (playerInRange)
            {
                if (isStandingStill)
                {
                    StandStill();
                }
                else
                {
                    MoveEnemy();
                    CheckSpawnEnemy();
                }
            }
        }
    }

    void MoveEnemy()
    {
        // Move the enemy towards the player.
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void CheckSpawnEnemy()
    {
        // Check if it's time to start standing still.
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            isStandingStill = true;
            timeSinceLastSpawn = 0f;  // Reset the timer.
        }
    }

    void StandStill()
    {
        // Stand still for the specified duration.
        standStillDuration -= Time.deltaTime;
        if (standStillDuration <= 0f)
        {
            SpawnEnemy();
            isStandingStill = false;
            standStillDuration = 2f;  // Reset the stand still duration.
        }
    }

    void SpawnEnemy()
    {
        // Calculate an offset position for the new enemy.
        Vector3 spawnPosition = transform.position + new Vector3(spawnOffset, 0f, 0f);

        // Instantiate a new enemy at the offset position.
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

}

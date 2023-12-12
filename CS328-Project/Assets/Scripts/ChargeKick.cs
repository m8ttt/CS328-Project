using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeKick : MonoBehaviour
{
    public float chargeSpeed = 2f; // Speed at which the enemy charges towards the player
    public float chargeDistance = 5f; // Distance at which the enemy starts charging
    public float aoeRadius = 3f; // AOE attack radius
    public float chargeCooldown = 3f; // Cooldown before the enemy can charge again
    public GameObject redIndicatorPrefab; // Prefab of the red indicator

    private Transform player;
    private bool isCharging = false;
    private float chargeTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isCharging)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < chargeDistance)
            {
                StartCharging();
            }
        }
        else
        {
            ChargeTowardsPlayer();
        }
    }

    private void StartCharging()
    {
        isCharging = true;
        chargeTimer = chargeCooldown;

        // Instantiate red indicator
        GameObject redIndicator = Instantiate(redIndicatorPrefab, transform.position, Quaternion.identity);
        Destroy(redIndicator, chargeCooldown);
    }

    private void ChargeTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, chargeSpeed * Time.deltaTime);

        chargeTimer -= Time.deltaTime;

        if (chargeTimer <= 0f)
        {
            isCharging = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the AOE attack radius in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }

}

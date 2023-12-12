using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lunge : MonoBehaviour
{
    public float indicatorInterval = 10f; // Interval between indicator appearances in seconds
    public float moveSpeed = 5f;
    public float lungeDuration = 2f; // Duration for the quick movement towards the player

    private float indicatorCooldown = 0f;
    private Vector2 playerLastPosition;
    private bool isLunging = false;

    // Update is called once per frame
    void Update()
    {
        if (!isLunging)
        {
            if (indicatorCooldown <= 0f)
            {
                // Show the indicator and start the lunge towards the last known location
                ShowIndicator();
                StartLunge();
                indicatorCooldown = indicatorInterval;
            }
            else
            {
                // Countdown the indicator cooldown
                indicatorCooldown -= Time.deltaTime;
            }
        }
        else
        {
            // Lunge towards the last known location
            LungeTowardsPlayer();
        }
    }

    void ShowIndicator()
    {
        // Create a line indicator from the enemy to the last known location of the player
        Debug.DrawLine(transform.position, playerLastPosition, Color.blue, indicatorInterval);
    }

    void StartLunge()
    {
        // Stop moving and initiate the lunge towards the last known location of the player
        isLunging = true;
        StopMoving();

        // Store the player's last known position for the lunge
        playerLastPosition = GetPlayerLastKnownPosition();

        // Start the countdown for the lunge duration
        Invoke("EndLunge", lungeDuration);
    }

    void LungeTowardsPlayer()
    {
        // Lunge towards the player's last known location
        Vector2 directionToPlayer = playerLastPosition - (Vector2)transform.position;
        transform.Translate(directionToPlayer.normalized * moveSpeed * Time.deltaTime);
    }

    void StopMoving()
    {
        // Add any logic to stop the movement of the sprite (e.g., setting velocity to zero)
    }

    void EndLunge()
    {
        // End the lunge and resume normal behavior
        isLunging = false;
    }

    Vector2 GetPlayerLastKnownPosition()
    {
        // You need to implement your logic to get the player's last known position.
        // This could be obtained from the player's script or other game components.
        // For now, let's assume the player has a script named PlayerMain.

        PlayerMain playerMain = FindObjectOfType<PlayerMain>();
        if (playerMain != null)
        {
            return playerMain.transform.position;
        }

        // If the player is not found, return the current position of the enemy.
        return transform.position;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTwo : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite fullHealthSprite;

    public int startHealth = 100;
    public int healthThreshold = 50;

    private int currentHealth;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = startHealth;

        // Set the initial sprite
        SetSprite();
    }

    void Update()
    {
        // Example: Decrease health over time
        // Replace this with your actual health decrease logic
        currentHealth -= 1;

        // Ensure health does not go below 0
        currentHealth = Mathf.Max(0, currentHealth);

        // Check if health is below the threshold
        if (currentHealth <= healthThreshold)
        {
            // Change sprite to full health sprite
            spriteRenderer.sprite = fullHealthSprite;
        }
        else
        {
            // Change sprite to normal sprite
            spriteRenderer.sprite = normalSprite;
        }
    }

    // Set the sprite based on current health
    private void SetSprite()
    {
        if (currentHealth <= healthThreshold)
        {
            spriteRenderer.sprite = fullHealthSprite;
        }
        else
        {
            spriteRenderer.sprite = normalSprite;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTwo : MonoBehaviour
{
    public string enemyName = "Boss";
    public int maxHealth = 100;
    public string[] phases = { "Phase 1", "Phase 2", "Phase 3" };
    public Sprite[] phaseSprites; // Add your sprite assets to this array

    private int currentPhase = 0;
    private int health;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial sprite
        if (phaseSprites.Length > 0)
        {
            spriteRenderer.sprite = phaseSprites[currentPhase];
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        if (currentPhase < phases.Length - 1)
        {
            currentPhase++;
            health = maxHealth;

            // Change the sprite for the new phase
            if (phaseSprites.Length > currentPhase)
            {
                spriteRenderer.sprite = phaseSprites[currentPhase];
            }

            Debug.Log($"{enemyName} respawned in phase {currentPhase + 1}");
        }
        else
        {
            Debug.Log($"{enemyName} has been defeated!");
            gameObject.SetActive(false); // or destroy the game object, depending on your requirements
        }
    }
}

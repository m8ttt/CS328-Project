using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20; 
    private int currentHealth;
    public float damageIndicatorDuration = 0.2f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(DamageIndicator());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator DamageIndicator()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageIndicatorDuration);
        spriteRenderer.color = originalColor;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

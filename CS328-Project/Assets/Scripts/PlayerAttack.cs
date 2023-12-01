using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    private KeyCode currentKey = KeyCode.None;
    public float attackRange = 1f;
    public string enemyTag = "Enemy";
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize currentKey to KeyCode.None at the start
        currentKey = KeyCode.None;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for key presses for attack directions
        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            currentKey = KeyCode.D;
        }
        else if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            currentKey = KeyCode.W;
        }
        else if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            currentKey = KeyCode.A;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            currentKey = KeyCode.S;
        }

        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger the attack animation based on the current key
            switch (currentKey)
            {
                case KeyCode.D:
                    animator.SetTrigger("AttackRight");
                    break;
                case KeyCode.W:
                    animator.SetTrigger("AttackTop");
                    break;
                case KeyCode.A:
                    animator.SetTrigger("AttackLeft");
                    break;
                case KeyCode.S:
                    animator.SetTrigger("AttackBottom");
                    break;
                default:
                    // Default case, no key pressed or unknown key
                    break;
            }
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Detect enemies with the specified tag in front of the player and destroy them
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Check if the collider belongs to an enemy with the specified tag
            if (enemy.CompareTag(enemyTag))
            {
                // Destroy the enemy
                Destroy(enemy.gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the attack range in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

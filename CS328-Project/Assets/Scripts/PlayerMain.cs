using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMain : MonoBehaviour
{

    public int maxHealth = 50;
    public int currentHealth;
    public int currentAttack;
    public HealthBarScript HB;
    public AttackDisplay AD;
    public float damageIndicatorDuration = 0.2f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if(HB == null){
            Debug.LogError("HealthBar script is not assigned to player!");
        }

        /*currentHealth = maxHealth;
        HB.setMaxHealth(maxHealth);*/

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }   


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            StartCoroutine(DamageIndicator());
            /*TakeDamage(10);*/
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        HB.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            HB.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
            Debug.Log("Die method called");
            animator.SetTrigger("Dead");
            Invoke("RestartGame", 1);
    }

      // Update is called once per frame
     void Update()
     {
            //damage test, delete 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Damage(10);
                StartCoroutine(DamageIndicator());
            }

     }


     public void addHealth(int value)
     {
            currentHealth += value;
            HB.SetHealth(currentHealth);
     }
     
     public void addAttack(int value)
     {
            currentAttack += value;
            AD.SetAttack(currentAttack);
     }


     //damage test, delete
     void Damage(int damage)
     {
            currentHealth -= damage;
            HB.SetHealth(currentHealth);
     }

     IEnumerator DamageIndicator()
     {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(damageIndicatorDuration);
            spriteRenderer.color = originalColor;
     }

     void RestartGame()
     {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }
}

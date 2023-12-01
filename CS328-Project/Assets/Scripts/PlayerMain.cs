using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    public int maxHealth = 50;
    public int currentHealth;
    public HealthBarScript HB;

    // Start is called before the first frame update
    void Start()
    {
        if(HB == null){
            Debug.LogError("HealthBar script is not assigned to player!");
        }
        /*currentHealth = maxHealth;
        HB.setMaxHealth(maxHealth);
        */
    }   


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("Joe has died!!!");
    }

    // Update is called once per frame
    void Update()
    {
        //damage test, delete 
        if (Input.GetKeyDown(KeyCode.Space)){
            Damage(10);
        }

    }


    public void addHealth(int value){
        currentHealth += value;
        HB.SetHealth(currentHealth);
    }
    
    //damage test, delete
    void Damage(int damage){
        currentHealth -= damage;
        HB.SetHealth(currentHealth);
    }

}

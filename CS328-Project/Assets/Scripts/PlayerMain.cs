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
        currentHealth = maxHealth;
        HB.setMaxHealth(maxHealth);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;
    public int maxHealth = 50;
    private int currentHealth;

    void Start(){
        currentHealth = maxHealth;

        if(slider != null){
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }else{
            Debug.LogError("Health slider is not assigned!");
        }
    }


    void UpdateHealthBar(){
        if(slider != null){
            slider.value = currentHealth;
        }
    }


    public void TakeDamage(int damage){
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthBar();

        if(currentHealth == 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("Joe is dead and all the pets were forever lost");
    }

    public Gradient gradient;
    public Image filling;

    public void setMaxHealth(int hp){
        slider.maxValue = hp;
        slider.value = hp;
        filling.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int hp){
        slider.value = hp;
        filling.color = gradient.Evaluate(slider.normalizedValue);
    }

}

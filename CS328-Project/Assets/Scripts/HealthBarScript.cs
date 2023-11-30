using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;
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

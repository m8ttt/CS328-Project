using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotions : MonoBehaviour
{
    [SerializeField] private int restoreVal;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            collision.GetComponent<PlayerMain>().addHealth(restoreVal);
            gameObject.SetActive(false);
        }
    }
}

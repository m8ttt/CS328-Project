using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPotions : MonoBehaviour
{
    [SerializeField] private int attackIncr;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            collision.GetComponent<PlayerMain>().addAttack(attackIncr);
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHazards : MonoBehaviour
{
    [SerializeField] private int harmVal;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            collision.GetComponent<PlayerMain>().TakeDamage(harmVal);
        }
    }
}

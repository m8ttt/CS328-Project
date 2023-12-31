using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{ 
    public int damage = 5;
   public Transform player;
   public float moveSpeed = 3f;
   //private Rigidbody2D rb;
   private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
        //rb.velocity = direction * moveSpeed;
        //movement = direction;
    }

    /*private void FixedUpdate(){
        moveCharacter(movement);
    }


    /*void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }*/


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            PlayerMain playerHealth = collision.gameObject.GetComponent<PlayerMain>();
            if(playerHealth != null){
                playerHealth.TakeDamage(damage);
            }
            //collision.gameObject.GetComponent<PlayerMain>().TakeDamage(damage);
        }
    }
}

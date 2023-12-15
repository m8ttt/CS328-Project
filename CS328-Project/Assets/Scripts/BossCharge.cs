using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : MonoBehaviour
{
    public float speed = 3f;
    public float chargeSpeed = 8f;
    public float chargeCooldown = 3f;
    private bool canCharge = true;
    public int damage = 15;

    public Transform player;

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            if (canCharge)
            {
                StartCoroutine(Charge());
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = direction * speed;
            }
        }
    }

    IEnumerator Charge()
    {
        canCharge = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(1f); // Adjust this to control the charge delay

        Vector2 chargeDirection = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = chargeDirection * chargeSpeed;

        yield return new WaitForSeconds(1f); // Adjust this to control the charge duration

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(chargeCooldown);
        canCharge = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMain playerHealth = collision.gameObject.GetComponent<PlayerMain>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            //collision.gameObject.GetComponent<PlayerMain>().TakeDamage(damage);
        }
    }
}

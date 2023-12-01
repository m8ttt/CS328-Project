using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float speed = 3f;
    public float attackRange = 2f;
    public int maxHealth = 100;
    public int attackDamage = 10;

    private int currentHealth;
    private Transform player;
    private Animator animator;

    private enum BossState
    {
        Idle,
        Move,
        Attack,
        Hurt,
        Dead
    }

    private BossState currentState;

    void Start()
    {
        currentState = BossState.Idle;
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (currentState)
        {
            case BossState.Idle:
                IdleState();
                break;
            case BossState.Move:
                MoveState();
                break;
            case BossState.Attack:
                AttackState();
                break;
            case BossState.Hurt:
                HurtState();
                break;
            case BossState.Dead:
                DeadState();
                break;
        }
    }

    void IdleState()
    {
        animator.SetTrigger("Idle");
    }

    void MoveState()
    {
        animator.SetTrigger("Move");
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < attackRange)
        {
            currentState = BossState.Attack;
        }
    }

    void AttackState()
    {
        animator.SetTrigger("Attack");
        player.GetComponent<PlayerMain>().TakeDamage(attackDamage);

        currentState = BossState.Idle;
    }

    void HurtState()
    {
        animator.SetTrigger("Hurt");
        currentState = BossState.Idle;
    }

    void DeadState()
    {
        animator.SetTrigger("Dead");
        StopAllCoroutines();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Optional: Disable other scripts
        // Example: GetComponent<YourCustomScript>().enabled = false;

        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentState = BossState.Dead;
        }
        else
        {
            currentState = BossState.Hurt;
        }
    }

    // Animation events
    public void AnimationEvent_Idle()
    {
        Debug.Log("Idle animation event");
    }

    public void AnimationEvent_Move()
    {
        Debug.Log("Move animation event");
    }

    public void AnimationEvent_Attack()
    {
        Debug.Log("Attack animation event");
        player.GetComponent<PlayerMain>().TakeDamage(attackDamage);
        currentState = BossState.Idle;
    }

    public void AnimationEvent_Hurt()
    {
        Debug.Log("Hurt animation event");
        currentState = BossState.Idle;
    }

    public void AnimationEvent_Dead()
    {
        Debug.Log("Dead animation event");
        StopAllCoroutines();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Optional: Disable other scripts
        // Example: GetComponent<YourCustomScript>().enabled = false;

        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

}


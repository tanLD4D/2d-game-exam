using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float damageRadius = 1f;
    [SerializeField] private float atttackSpeed = 0.5f;


    float attackSpeedTimeer = 0f;
    Animator animator;
    Transform playerTarget;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        FindPlayer();
        AttackControll();
    }

    void AttackControll()
    {
        if(attackSpeedTimeer > 0f)
        {
            attackSpeedTimeer -= Time.deltaTime;
            if (attackSpeedTimeer <= 0f) attackSpeedTimeer = 0f;
        }

        if (attackSpeedTimeer <= 0f && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && Vector2.Distance(playerTarget.position, transform.position) <= damageRadius)
        {
            attackSpeedTimeer = 1f / atttackSpeed;
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        if(Vector2.Distance(playerTarget.position, transform.position) <= damageRadius)
        {
            playerTarget.gameObject.GetComponent<IDamageble>().TakeDamage(damage);
        }
    }

    void FindPlayer()
    {
        if (playerTarget) return;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }
}

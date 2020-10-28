using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagedEnemy : Enemy
{
    public LayerMask targetLayer;
    public LayerMask obstacleLayer;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float bulletSpeed = 50f;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackSpeed = 1.5f;



    float attackSpeedTimer = 0f;

    Transform playerTarget;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    private void Update()
    {
        FindPlayer();
        AttackController();
    }

    void AttackController()
    {

        if (attackSpeedTimer > 0f)
        {
            attackSpeedTimer -= Time.deltaTime;
            if (attackSpeedTimer < 0f) attackSpeedTimer = 0f;
        }
        
        if (playerTarget && CanAttack() && Vector2.Distance(playerTarget.position,transform.position) <= attackDistance)
        {
            
            if (attackSpeedTimer <= 0f)
            {
                
                attackSpeedTimer = 1f / attackSpeed;
                Attack();
            }
        }
    }

    //Check for in attack direction can attack, or has obstacle in attack direction?
    bool CanAttack()
    {
        LookToTarget();

        if (Physics2D.Raycast(attackPoint.position, attackPoint.up, attackDistance, obstacleLayer))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void LookToTarget()
    {
        //Axis calculate for attackPoint lookAt target
        Vector3 targetPos = playerTarget.position - transform.position;
        targetPos.Normalize();
        float zAxis = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.Euler(0f, 0f, zAxis - 90f);
    }

    void Attack()
    {
        //Spawn bullet
        
        GameObject spawnedFireBall = Instantiate(fireBall, attackPoint.position, attackPoint.rotation);
        spawnedFireBall.GetComponent<Rigidbody2D>().AddForce(spawnedFireBall.transform.up * bulletSpeed);
        spawnedFireBall.GetComponent<FIreBall>().damage = damage;
        Destroy(spawnedFireBall, 5f);
    }

    void FindPlayer()
    {
        if(playerTarget == null)
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : Enemy
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float durationTime = 2f;
    private float durationTimerCount = 0;

    public Transform[] pathTargets;

    int currentPathIndex = 0;
    Transform currntPathTarget;

    private void Start()
    {
        currntPathTarget = pathTargets[0];
    }


    private void FixedUpdate()
    {
        DurationCount();
        Move();
    }

    void DurationCount()
    {
        durationTimerCount -= Time.fixedDeltaTime;
        if (durationTimerCount < 0f) durationTimerCount = 0f;
    }

    void Move()
    {
        if(durationTimerCount <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, currntPathTarget.position, speed * Time.fixedDeltaTime);
            CheckDistance();
        }
    }

    void CheckDistance()
    {
        float distance = Vector2.Distance(transform.position, currntPathTarget.position);
        if(distance <= 0.2f)
        {
            ChangPathTarget();
        }
    }

    void ChangPathTarget()
    {
        if(currentPathIndex < pathTargets.Length - 1)
        {
            currentPathIndex++;
        }
        else
        {
            currentPathIndex = 0;
        }

        currntPathTarget = pathTargets[currentPathIndex];
        durationTimerCount = durationTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
            if(damageble != null)
            {
                damageble.TakeDamage(damage);
            }
        }
    }
}

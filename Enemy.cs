using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageble
{
    [SerializeField]protected float damage = 5f;
    [SerializeField]protected float health = 10f;

    [SerializeField]protected GameObject deadEffect;

    public void TakeDamage(float damage)
    {
        if (health <= 0f) return;
        health -= damage;
        if (health <= 0f) Dead();
    }

    protected void Dead()
    {
        if (deadEffect) Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 3f);
        Destroy(gameObject);
    }
}

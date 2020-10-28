using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerState : MonoBehaviour,IDamageble
{
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            health = 0f;
            Dead();
        }
    }

    void Dead()
    {
        if (deadEffect) Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 3f);
        gameObject.SetActive(false);
    }
}

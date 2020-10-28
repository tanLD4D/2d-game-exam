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
       //Script
    }
}

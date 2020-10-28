using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreBall : MonoBehaviour
{
    public float damage { private get; set; }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
        if (damageble != null)
        {
            damageble.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}

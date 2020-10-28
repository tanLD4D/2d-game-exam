using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : MonoBehaviour
{
    public GameObject magicBall;
    public float magicSpeed = 15f;
    public float timeToDestroy = 5f;
    public float attackDamage = 5f;

    [SerializeField] private IsometricCharacterRenderer isoRender;

    public void ShotMagicBall()
    {
        GameObject magicBallSpawned = Instantiate(magicBall, transform.position, Quaternion.Euler(0f, 0f, isoRender.GetFaceAnlge()));
        magicBallSpawned.GetComponent<Rigidbody2D>().AddForce(magicBallSpawned.transform.up * magicSpeed);
        magicBallSpawned.GetComponent<FIreBall>().damage = attackDamage;
        Destroy(magicBallSpawned, timeToDestroy);
    }
}

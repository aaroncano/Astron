using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBulletMovement : MonoBehaviour
{
    public float Damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.GetComponent<CommonEnemyBulletScript>().DestroyBullet();
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakekingDamage(Damage);
        }
    }
}

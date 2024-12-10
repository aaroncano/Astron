using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyDamage : MonoBehaviour
{
    public float Damage = 1f;
    public GameObject DeadEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakekingDamage(Damage);
            Destroy(Instantiate(DeadEffect, transform.position, Quaternion.identity), 3f);
            Destroy(gameObject);
        }

    }
}

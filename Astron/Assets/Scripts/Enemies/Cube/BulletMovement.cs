using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float BulletSpeed;
    private float Damage = 1f;

    private Transform Player;
    private Vector2 Target;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Target = new Vector2(Player.position.x, Player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, BulletSpeed * Time.deltaTime);
        if (transform.position.x == Target.x && transform.position.y == Target.y)
        {
            gameObject.GetComponent<CommonEnemyBulletScript>().DestroyBullet();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.GetComponent<CommonEnemyBulletScript>().DestroyBullet();
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakekingDamage(Damage);
        }
    }

}

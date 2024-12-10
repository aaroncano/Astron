using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondDamage : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform[] FiringPoints;
    public GameObject DeadEffect;
    public float FireRate;
    public float BulletSpeed;

    private float WaitForShot;
    private Transform Player;
    private float Damage = 1f;
    private Camera Cam;
    private Vector3 InCamera;

    private void Start()
    {
        WaitForShot = FireRate;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Cam = Camera.main;
    }

    private void Update()
    {
        InCamera = Cam.WorldToViewportPoint(transform.position);
        if (InCamera.x > 0 && InCamera.x < 1 && InCamera.y > 0 && InCamera.y < 1)
        {
            if (WaitForShot <= 0)
            {
                FindObjectOfType<AudioManager>().Play("EnemyShotDiamond");
                foreach(Transform FiringPoint in FiringPoints)
                {
                    shoot(FiringPoint);
                }
                WaitForShot = FireRate;
            }
            else
            {
                WaitForShot -= Time.deltaTime;
            }
        }
    }

    void shoot(Transform FiringPoint)
    {
        GameObject Bullet = Instantiate(BulletPrefab, FiringPoint.position, FiringPoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FiringPoint.up * BulletSpeed, ForceMode2D.Impulse);
    }

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

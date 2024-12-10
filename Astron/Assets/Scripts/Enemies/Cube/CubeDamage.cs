using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDamage : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject FiringPoint;

    public float WaitForShot;
    public float FireRate;
    private Transform Player;

    public float Damage = 1f;
    public GameObject DeadEffect;

    Camera Cam;
    Vector3 InCamera;

    private void Start()
    {
        WaitForShot = FireRate;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Cam = Camera.main;
    }

    private void Update()
    {
        InCamera = Cam.WorldToViewportPoint(transform.position);
        if(InCamera.x > 0 && InCamera.x < 1 &&    InCamera.y > 0  && InCamera.y < 1)
        {
            if (WaitForShot <= 0)
            {
                FindObjectOfType<AudioManager>().Play("EnemyShotSquare");
                Destroy(Instantiate(Bullet, FiringPoint.transform.position, FiringPoint.transform.rotation), 4f);
                WaitForShot = FireRate;
            }
            else
            {
                WaitForShot -= Time.deltaTime;
            }
        }
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

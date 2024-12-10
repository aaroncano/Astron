using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletEffect;

    private Camera Cam;

    private void Start()
    {
        //Playing sound
        FindObjectOfType<AudioManager>().Play("PlayerShot");

        if (FindObjectOfType<shooting>().Hardness == true) GetComponent<BoxCollider2D>().isTrigger = true;
        Cam = Camera.main;
    }

    private void Update()
    {
        outland();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(Instantiate(BulletEffect, transform.position, Quaternion.identity), 3f);
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (FindObjectOfType<shooting>().Freezness == true)
            {
                other.gameObject.GetComponent<EnemyCommonScript>().FreezeUp();
            }
            other.gameObject.GetComponent<EnemyHealth>().TakekingDamage(FindObjectOfType<shooting>().Damage);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Upgrade"))
        {
            Destroy(Instantiate(BulletEffect, transform.position, Quaternion.identity), 3f);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (FindObjectOfType<shooting>().Freezness == true)
            {
                other.gameObject.GetComponent<EnemyCommonScript>().FreezeUp();
            }
            other.gameObject.GetComponent<EnemyHealth>().TakekingDamage(FindObjectOfType<shooting>().Damage);
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.GetComponent<CommonEnemyBulletScript>().DestroyBullet();
        }
    }

    void outland()
    {
        Vector3 InCamera = Cam.WorldToViewportPoint(transform.position);
        if (!(InCamera.x > 0 && InCamera.x < 1 && InCamera.y > 0 && InCamera.y < 1))
        {
            Destroy(gameObject);
        }
    }
}

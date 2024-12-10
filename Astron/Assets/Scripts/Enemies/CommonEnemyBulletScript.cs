using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyBulletScript : MonoBehaviour
{
    public GameObject BulletExplosion;

    private void Start()
    {
        Invoke("DestroyBullet", 4.5f);
    }

    public void DestroyBullet()
    {
        Destroy(Instantiate(BulletExplosion, transform.position, Quaternion.identity), 2f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public void Initial(Transform[] Firingpoints, GameObject Bulletprefab, float BulletSpeed)
    {
        GameObject Bullet = Instantiate(Bulletprefab, Firingpoints[0].position, Firingpoints[0].rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Firingpoints[0].up * BulletSpeed, ForceMode2D.Impulse);
    }

    public void Around(Transform[] Firingpoints, GameObject Bulletprefab, float BulletSpeed)
    {
        foreach(Transform FiringPoint in Firingpoints)
        {
            GameObject Bullet = Instantiate(Bulletprefab, FiringPoint.position, FiringPoint.rotation);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FiringPoint.up * BulletSpeed, ForceMode2D.Impulse);
        }
    }

    public void Triple(Transform[] FrontalFP, GameObject Bulletprefab, float BulletSpeed)
    {
        foreach(Transform FP in FrontalFP)
        {
            GameObject Bullet = Instantiate(Bulletprefab, FP.transform.position, FP.transform.rotation);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FP.up * BulletSpeed, ForceMode2D.Impulse);
        }
    }

    public void Double(Transform[] Firingpoints, GameObject Bulletprefab, float BulletSpeed)
    {
        foreach(Transform FP in Firingpoints)
        {
            GameObject Bullet = Instantiate(Bulletprefab, FP.position, FP.rotation);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FP.up * BulletSpeed, ForceMode2D.Impulse);
        }
    }

    public void Sides(Transform[] Firingpoints, GameObject Bulletprefab, float BulletSpeed)
    {
        foreach(Transform FP in Firingpoints)
        {
            GameObject Bullet = Instantiate(Bulletprefab, FP.position, FP.rotation);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FP.up * BulletSpeed, ForceMode2D.Impulse);
        }
    }
}

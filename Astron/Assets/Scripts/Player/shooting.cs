using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform[] AroundFP;
    public Transform[] TripleFP;
    public Transform[] DoubleFP;
    public Transform[] SidesFP;


    public GameObject Bulletprefab;
    public float BulletSpeed;
    public float[] Firerate;

    float WaitForFire;

    Weapons Weapons;
    PlayerHealth ph;

    public GameObject BombExplosion;

    //upgrades
    public int BombCounter;
    public int FRpos;
    public int WeaponType;
    public bool Hardness;
    public bool /*Petrifiacion*/ Freezness;
    public bool /*Thrust*/ Pushness;
    public int Damage;
  

    public bool CanShoot;

    private void Start()
    {
        ph = FindObjectOfType<PlayerHealth>();
        Weapons = FindObjectOfType<Weapons>();
        CanShoot = true;
    }

    void Update()
    {
        if(PauseMenu.GameIsPaused == false)
        {
            if (Input.GetMouseButton(0) && WaitForFire < Time.time)
            {
                Shoot();
                WaitForFire = Time.time + Firerate[FRpos];
            }
            if (Input.GetKeyDown(KeyCode.Space) && BombCounter > 0)
            {
                if(FindObjectOfType<RandomSpawn>().Wave == FindObjectOfType<RandomSpawn>().PreWave)
                {
                    ActivateBomb();
                }
            }
        }
    }

    void Shoot()
    {
        if(CanShoot == true)
        {
            if (gameObject.GetComponent<Renderer>().enabled == true)
            {
                if (WeaponType == 0)
                {
                    Weapons.Initial(AroundFP, Bulletprefab, BulletSpeed);
                }
                else if (WeaponType == 1)
                {
                    Weapons.Double(DoubleFP, Bulletprefab, BulletSpeed);
                }
                else if (WeaponType == 2)
                {
                    Weapons.Around(AroundFP, Bulletprefab, BulletSpeed);
                }
                else if (WeaponType == 3)
                {
                    Weapons.Triple(TripleFP, Bulletprefab, BulletSpeed);
                }
                else if(WeaponType == 4)
                {
                    Weapons.Sides(SidesFP, Bulletprefab, BulletSpeed);
                }
            }
        }
    }

    void ActivateBomb()
    {
        FindObjectOfType<AudioManager>().Play("Bomb");
        Destroy(Instantiate(BombExplosion, transform.position, Quaternion.identity), 2f);
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<EnemyHealth>().Health = 0;
        }
        foreach(GameObject Bullet in Bullets)
        {
            Destroy(Bullet);
        }
        BombCounter--;
    }
}

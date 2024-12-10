using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    private RandomSpawn Spawn;
    private PlayerHealth PlayerHealth;
    private shooting Shooting;
    private Bullet Bullet;


    public GameObject[] Upgrades;
    public GameObject[] Gadgets;

    private void Start()
    {
        Spawn = FindObjectOfType<RandomSpawn>();
        Shooting = FindObjectOfType<shooting>();
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        Bullet = FindObjectOfType<Bullet>();
    }

    public void Intermission(int Wave)
    {
        int Num = Random.Range(0, 101);

        if (Wave % 2 == 0)
        {
            //Debug.Log("Intermission Even");
            Vector2 Pos = new Vector2(0, 4.5f);
            if (Num <= 20) Instantiate(Upgrades[0], Pos, Quaternion.identity);
            else if (Num <= 25) Instantiate(Upgrades[1], Pos, Quaternion.identity);
            else if (Num <= 30) Instantiate(Upgrades[2], Pos, Quaternion.identity);
            else if (Num <= 56) Instantiate(Upgrades[3], Pos, Quaternion.identity);
            else if (Num <= 61) Instantiate(Upgrades[4], Pos, Quaternion.identity);
            else if (Num <= 71) Instantiate(Upgrades[5], Pos, Quaternion.identity);
            else if (Num <= 78) Instantiate(Upgrades[6], Pos, Quaternion.identity);
            else if (Num <= 88) Instantiate(Upgrades[7], Pos, Quaternion.identity);
            else if (Num <= 95) Instantiate(Upgrades[8], Pos, Quaternion.identity);
            else if (Num <= 100) Instantiate(Upgrades[9], Pos, Quaternion.identity);
        }
        else
        {
            //Debug.Log("Intermision Odd");
            Vector2 Pos = new Vector2(0, 4.5f);
            if (Num <= 30)
            {
                Instantiate(Gadgets[0], Pos, Quaternion.identity);
            }
            else if(Num <= 60)
            {
                Instantiate(Gadgets[1], Pos, Quaternion.identity);
            }
        }
    }


}


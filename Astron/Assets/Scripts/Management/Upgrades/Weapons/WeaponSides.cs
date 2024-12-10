﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSides : MonoBehaviour
{
    public GameObject DisplayScore;
    public float WeaponPoints;

    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().WeaponType == 4)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shooting Shooting = other.GetComponent<shooting>();
            if (Shooting.WeaponType != 4)
            {
                Shooting.WeaponType = 4;

                GameObject Dscore = Instantiate(DisplayScore, transform.position + new Vector3(3, 0), Quaternion.identity);
                Dscore.GetComponent<DisplayNewScore>().GetPoints(WeaponPoints);
                FindObjectOfType<Manager>().score += WeaponPoints;

                gameObject.GetComponent<UpgradeHealth>().DestroyUpdate();
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gadget_Bomb : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().BombCounter >= 9)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("BombTaken");
            shooting Shooting = other.GetComponent<shooting>();

            if (Shooting.BombCounter < 9)
            {
                Shooting.BombCounter++;

                GameObject[] Upgrades = GameObject.FindGameObjectsWithTag("Upgrade");
                foreach (GameObject Upgrade in Upgrades)
                {
                    Upgrade.GetComponent<UpgradeHealth>().DestroyUpdate();
                    Destroy(Upgrade);
                }
            }
        }
    }
}

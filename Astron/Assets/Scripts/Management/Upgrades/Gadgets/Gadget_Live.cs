using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gadget_Live : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<PlayerHealth>().Health >= 9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth Ph = FindObjectOfType<PlayerHealth>();

        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("LiveTaken");
            if(Ph.Health < 9)
            {
                Ph.Health++;

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

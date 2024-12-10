using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_FireRate : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().FRpos == 5)
        {
            Destroy(gameObject);
        }

    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shooting Shooting = other.GetComponent<shooting>();

            if(Shooting.FRpos < 5)
            {
                Shooting.FRpos++;

                gameObject.GetComponent<UpgradeHealth>().DestroyUpdate();
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Damage : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().Damage >= 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shooting Shooting = other.GetComponent<shooting>();

            if (Shooting.Damage < 5)
            {
                Shooting.Damage++;

                gameObject.GetComponent<UpgradeHealth>().DestroyUpdate();
                Destroy(gameObject);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Petrification : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().Freezness == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shooting Shooting = other.GetComponent<shooting>();

            if (Shooting.Freezness == false)
            {
                Shooting.Freezness = true;
                if (FindObjectOfType<shooting>().Pushness == true) FindObjectOfType<shooting>().Pushness = false;

                gameObject.GetComponent<UpgradeHealth>().DestroyUpdate();
                Destroy(gameObject);
            }
        }
    }
}

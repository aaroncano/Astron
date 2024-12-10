using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Thrust : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().Pushness == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shooting Shooting = other.GetComponent<shooting>();

            if (Shooting.Pushness == false)
            {
                Shooting.Pushness = true;
                if (FindObjectOfType<shooting>().Freezness == true) FindObjectOfType<shooting>().Freezness = false;
                if (FindObjectOfType<shooting>().Hardness == true) FindObjectOfType<shooting>().Hardness = false;

                gameObject.GetComponent<UpgradeHealth>().DestroyUpdate();
                Destroy(gameObject);
            }
        }
    }
}

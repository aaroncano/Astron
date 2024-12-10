using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Hardness : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().Hardness == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shooting Shooting = other.GetComponent<shooting>();

            if (Shooting.Hardness == false)
            {
                Shooting.Hardness = true;

                if (FindObjectOfType<shooting>().Freezness == true) FindObjectOfType<shooting>().Freezness = false;

                gameObject.GetComponent<UpgradeHealth>().DestroyUpdate();
                Destroy(gameObject);
            }
        }
    }

}

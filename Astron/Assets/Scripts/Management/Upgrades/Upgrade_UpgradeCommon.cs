using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_UpgradeCommon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("UpgradeTaken");
        }
    }
}

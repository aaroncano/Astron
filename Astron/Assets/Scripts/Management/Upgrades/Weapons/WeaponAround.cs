using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAround : MonoBehaviour
{
    public float WeaponPoints;
    public GameObject DisplayScore;

    private void Start()
    {
        Destroy(gameObject, 6f);
        if (FindObjectOfType<shooting>().WeaponType == 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shooting Shooting = other.GetComponent<shooting>();
            if (Shooting.WeaponType != 2)
            {
                Shooting.WeaponType = 2;

                GameObject Dscore = Instantiate(DisplayScore, transform.position + new Vector3(3,0), Quaternion.identity);
                Dscore.GetComponent<DisplayNewScore>().GetPoints(WeaponPoints);
                FindObjectOfType<Manager>().score += WeaponPoints;

                gameObject.GetComponent<UpgradeHealth>().DestroyUpdate();
                Destroy(gameObject);
            }
        }
    }

}

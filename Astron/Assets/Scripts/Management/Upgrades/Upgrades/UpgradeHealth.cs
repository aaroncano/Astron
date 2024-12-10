using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : MonoBehaviour
{
    public GameObject UpgradeTaken;
    public GameObject DisplayName;
    [SerializeField] private string UpgradeName = "0";

    private void Start()
    {
        Invoke("DestroyUpdate", 5.99f);
    }

    public void DestroyUpdate()
    {
        Destroy(Instantiate(UpgradeTaken, transform.position, Quaternion.identity), 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject name = Instantiate(DisplayName, transform.position + new Vector3(0,2f,0), Quaternion.identity);
            name.GetComponent<DisplayNewUpgrade>().GetName(UpgradeName);
        }
    }

}

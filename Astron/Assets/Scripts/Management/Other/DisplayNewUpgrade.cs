using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayNewUpgrade : MonoBehaviour
{
    public TextMeshProUGUI NewName;
    private Vector3 pos;

    private void Start()
    {
        Destroy(gameObject, 1.6f);
    }

    private void Update()
    {
        pos = Camera.main.WorldToScreenPoint(transform.position);
        NewName.transform.position = pos;
    }

    public void GetName(string name)
    {
        NewName.text = name;
        NewName.gameObject.SetActive(true);
    }
}

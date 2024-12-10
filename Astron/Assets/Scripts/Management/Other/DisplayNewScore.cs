using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNewScore : MonoBehaviour
{
    public TextMeshProUGUI NewPoints;
    private Vector3 pos;

    private void Start()
    {
        Destroy(gameObject, 1.2f);
    }

    private void Update()
    {
        pos = Camera.main.WorldToScreenPoint(transform.position);
        NewPoints.transform.position = new Vector2(pos.x, pos.y);
    }

    public void GetPoints(float points)
    {
        NewPoints.text = points.ToString("N0");
        NewPoints.gameObject.SetActive(true);
    }
}

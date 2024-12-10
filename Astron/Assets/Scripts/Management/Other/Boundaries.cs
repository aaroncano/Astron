using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    Camera MainCamera;
    private Vector2 Screenbound;
    private float ObjectWidth;
    private float ObjectHeight;

    private void Start()
    {
        MainCamera = Camera.main;
        Screenbound = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        ObjectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        ObjectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void Update()
    {
        Vector3 ViewPos = transform.position;
        ViewPos.x = Mathf.Clamp(ViewPos.x, Screenbound.x * -1 + ObjectWidth, Screenbound.x - ObjectWidth);
        ViewPos.y = Mathf.Clamp(ViewPos.y, Screenbound.y * -1 + ObjectHeight, Screenbound.y - ObjectHeight);
        transform.position = ViewPos;
    }

}

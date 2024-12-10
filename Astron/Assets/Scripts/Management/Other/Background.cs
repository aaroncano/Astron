using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Stars;
    public GameObject Blue;

    private void Start()
    {
        Instantiate(Stars, new Vector3(0,0,9), Quaternion.identity);
        Instantiate(Blue, new Vector3(0,0,2), Quaternion.identity);
    }
}

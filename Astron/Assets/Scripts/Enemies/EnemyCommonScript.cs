using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommonScript : MonoBehaviour
{

    Rigidbody2D rb;
    [NonSerialized]public bool FreezeNow = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (FindObjectOfType<shooting>().Pushness == true) PushnessUp();
    }

    public void FreezeUp()
    {
        StopAllCoroutines();
        float InitialDrag = rb.drag;
        rb.drag = 500;
        FreezeNow = true;
        StartCoroutine(WaitFreezing(InitialDrag));
    }
    IEnumerator WaitFreezing(float InitialDrag)
    {
        yield return new WaitForSeconds(1f);
        rb.drag = InitialDrag;
        FreezeNow = false;
    }

    public void PushnessUp()
    {
        rb.mass = rb.mass / 12f;
    }

}

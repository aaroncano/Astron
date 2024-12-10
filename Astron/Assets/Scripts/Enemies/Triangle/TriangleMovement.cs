using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    public float Speed = 6f;
    private Transform Target;
    private Vector3 Goto;

    private bool Freezing;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Goto = -transform.position;
    }
    private void Update()
    {
        Freezing = gameObject.GetComponent<EnemyCommonScript>().FreezeNow;
        if (Target.gameObject.activeSelf)
        {
            if(Freezing == false)
            {
                transform.Rotate(0, 0, 300 * Time.deltaTime);
                if (transform.position != Goto)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Goto, Speed * Time.deltaTime);
                }
                else
                {
                    Goto = -transform.position;
                }
            }
        }
    }

}

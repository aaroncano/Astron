using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float Speed;
    public float StopDistance;
    public float Retreat;

    private Transform Target;
    Rigidbody2D rb;

    private bool Freezing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        //rotacion
        Vector3 direction = Target.position - transform.position;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = rotation;

        Freezing = gameObject.GetComponent<EnemyCommonScript>().FreezeNow;
        //seguimiento y huida
        if (Target.gameObject.activeSelf)
        {
            if(Freezing == false)
            {
                if (Vector2.Distance(transform.position, Target.position) > StopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, Target.position) < StopDistance && Vector2.Distance(transform.position, Target.position) > Retreat)
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, Target.position) < Retreat)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Target.position, -Speed * Time.deltaTime);
                }
            }
        }
    }
}

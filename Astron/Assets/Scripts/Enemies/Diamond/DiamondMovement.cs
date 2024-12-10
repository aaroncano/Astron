using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMovement : MonoBehaviour
{
    public float Speed;
    public float StopDistance;
    public float Retreat;

    private Transform Player;
    Rigidbody2D rb;

    private bool Freezing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        //rotacion
        transform.Rotate(0, 0, 300 * Time.deltaTime);

        //seguimiento y huida
        Freezing = gameObject.GetComponent<EnemyCommonScript>().FreezeNow;
        if (Player.gameObject.activeSelf)
        {
            if(Freezing == false)
            {
                if (Vector2.Distance(transform.position, Player.position) > StopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, Player.position) < StopDistance && Vector2.Distance(transform.position, Player.position) > Retreat)
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, Player.position) < Retreat)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, -Speed * Time.deltaTime);
                }
            }
        }
    }
}

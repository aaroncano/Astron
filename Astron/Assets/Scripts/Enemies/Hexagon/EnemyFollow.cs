using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float Speed = 5f;
    private Transform Target;

    private bool Freezing;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        Freezing = gameObject.GetComponent<EnemyCommonScript>().FreezeNow;
        transform.Rotate(0,0,200 * Time.deltaTime); //rotación del enemigo *estetico*
        if (Target.gameObject.activeSelf)
        {
            if(Freezing == false)
            {
                transform.position = Vector2.MoveTowards(gameObject.transform.position, Target.position, Speed * Time.deltaTime);
            }
        }
    }

}

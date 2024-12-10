using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    private Vector2 MoveDir;
    private Vector2 mousedirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveInput();
        MouseInput();
    }

    private void FixedUpdate()
    {
        Move();
        MouseDir();
    }

    //MOVIMIENTO
    void MoveInput()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");
        MoveDir = new Vector2(MoveX, MoveY).normalized;
    }

    void Move()
    {
        //rb.velocity = new Vector2(MoveDir.x * Speed, MoveDir.y * Speed);
        rb.AddForce(new Vector2(MoveDir.x * Speed, MoveDir.y * Speed));
    }


    //MOUSE - DIRECCION DE MIRA
    void MouseInput()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        mousedirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
    }
    void MouseDir()
    {
        transform.up = mousedirection;
    }


    //End of the wave
    public void StopMoving()

    {
        float RSpeed = Speed;
        Speed = 0f;
        float RDrag = rb.drag;
        rb.drag = 60f;
        FindObjectOfType<shooting>().CanShoot = false;
        StartCoroutine(waiting(RSpeed, RDrag));

    }
    IEnumerator waiting(float RSpeed, float RDrag)
    {
        yield return new WaitForSeconds(0.8f);
        FindObjectOfType<shooting>().CanShoot = true;
        Speed = RSpeed;
        rb.drag = RDrag;
    }



}

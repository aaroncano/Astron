using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyHealth : MonoBehaviour
{
    public GameObject DeadEffect;
    public GameObject DisplayPoints;
    public float MaxHealth;
    public float Health;

    public float EnemyPoints;
    private Manager manager;

    Rigidbody2D rb;

    private void Start()
    {
        Health = MaxHealth;
        manager = FindObjectOfType<Manager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Health <= 0)
        {
            getpoints();
        }
    }

    public void TakekingDamage(float dmg)
    {
            Health -= dmg;
    }

    void getpoints()
    {
        if(Health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDead");
            Destroy(Instantiate(DeadEffect, transform.position, Quaternion.identity), 3f);
            Destroy(gameObject);
            manager.score += EnemyPoints;
            GameObject newpoints = Instantiate(DisplayPoints, transform.position, Quaternion.identity);
            newpoints.GetComponent<DisplayNewScore>().GetPoints(EnemyPoints);
        }

    }

    //Mass = 0 for PointEffector
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float OriginalMass = rb.mass;
            rb.mass = 1;
            StartCoroutine(Wait(OriginalMass));

        }
    }
    IEnumerator Wait(float OriginalMass)
    {
        yield return new WaitForSeconds(1f);
        rb.mass = OriginalMass;

    }


}

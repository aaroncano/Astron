using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float Health;
    public GameObject DeadPlayerEffect;
    Renderer render;
    public TrailRenderer[] Trails;
    PointEffector2D PE;
    CircleCollider2D CC;
    private Vector3 DeathPos;

    public GameObject UI;
    public GameObject PMenu;

    private void Start()
    {
        Health = MaxHealth;
        render = GetComponent<Renderer>();
        PE = GetComponent<PointEffector2D>();
        CC = GetComponent<CircleCollider2D>();
        PE.enabled = false;
        CC.enabled = false;
    }

    public void TakekingDamage(float dmg)
    {
        FindObjectOfType<AudioManager>().Play("PlayerExplosion");
        Health -= dmg;
        DeadPlayerOn();
        if (Health <= 0)
        {
            UI.SetActive(false);
            PMenu.SetActive(false);
            Invoke("stopgame", 1.3f);
            if (FindObjectOfType<Manager>().score > PlayerPrefs.GetFloat("Score3"))
            {
                FindObjectOfType<HighScoreTable>().OpenHighScoreTable();
            }
            else
            {
                Invoke("GG", 0.5f);
            }
        }
    }

    void stopgame()
    {
        Time.timeScale = 0;
    }

    void GG()
    {
        FindObjectOfType<YouLost>().GGman();
    }

    void DeadPlayerOn()
    {
        DeathPos = transform.position;
        Destroy(Instantiate(DeadPlayerEffect, transform.position, Quaternion.identity), 3f);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets) Destroy(bullet);
        render.enabled = false;
        trailsD();

        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 1)
        {
            CC.enabled = true;
            PE.enabled = true;
        }

        Invoke("DeadPlayerOff", 0.5f);
    }
    void DeadPlayerOff()
    {
        CC.enabled = false;
        PE.enabled = false;
        if (Health >= 1)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                transform.position = DeathPos;
            }
            render.enabled = true;
            trailsA();
        }
    }


    //Aparecer y desaparecer trails.
    public void trailsD()
    {
        foreach (TrailRenderer Trail in Trails) Trail.enabled = false;
    }
    public void trailsA()
    {
        foreach (TrailRenderer Trail in Trails) Trail.enabled = true;
    }
}

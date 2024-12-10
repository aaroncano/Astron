using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI BombsText;

    private float PlayerLives;
    private int Wave;
    private int Bombs;

    private void Start()
    {
        WaveText.text = "WAVE: " + Wave;
        score = 0f;
        LivesText.text = "X" + PlayerLives;
        BombsText.text = "X" + Bombs;
    }

    void Update()
    {
        Wave = FindObjectOfType<RandomSpawn>().Wave;
        PlayerLives = FindObjectOfType<PlayerHealth>().Health;
        Bombs = FindObjectOfType<shooting>().BombCounter;
        scoref();
        livesf();
        wavef();
        Bombsf();
    }

    void scoref()
    {
        ScoreText.text = "S C O R E : " + score.ToString("N0");
    }

    void livesf()
    {
        LivesText.text = "X " + PlayerLives;
    }

    void wavef()
    {
        WaveText.text = "W A V E : " + Wave;
    }

    void Bombsf()
    {
        BombsText.text = "X " + Bombs;
    }

}

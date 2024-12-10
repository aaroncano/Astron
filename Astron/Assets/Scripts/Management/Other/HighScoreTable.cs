using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HighScoreTable : MonoBehaviour
{
    public TextMeshProUGUI[] Names;
    public TextMeshProUGUI[] Scores;
    public GameObject NewNamePanel;
    public GameObject TablePanel;

    public int NamePos;

    private void Start()
    {
        Scores[0].text = PlayerPrefs.GetFloat("Score1", 0f).ToString("N0");
        Scores[1].text = PlayerPrefs.GetFloat("Score2", 0f).ToString("N0");
        Scores[2].text = PlayerPrefs.GetFloat("Score3", 0f).ToString("N0");

        Names[0].text = PlayerPrefs.GetString("Name1", "AstronFan");
        Names[1].text = PlayerPrefs.GetString("Name2", "AstronFan");
        Names[2].text = PlayerPrefs.GetString("Name3", "AstronFan");
    }

    public void OpenHighScoreTable()
    {
        TablePanel.SetActive(true);
        CheckForPlaces(FindObjectOfType<Manager>().score);
    }

    private void CheckForPlaces(float score)
    {
        if (score > PlayerPrefs.GetFloat("Score1")) FirstPlace(score);
        else if (score > PlayerPrefs.GetFloat("Score2")) SecondPlace(score);
        else if (score > PlayerPrefs.GetFloat("Score3")) ThirdPlace(score);
    }

    public void FirstPlace(float score)
    {
        NamePos = 1;
        NewNamePanel.SetActive(true);
    }
    public void SecondPlace(float score)
    {
        NamePos = 2;
        NewNamePanel.SetActive(true);
    }
    public void ThirdPlace(float score)
    {
        NamePos = 3;
        NewNamePanel.SetActive(true);
    }

    public void UpdateNewName(string Name)
    {
        if (NamePos == 1)
        {
            //Actualizar nombres
            PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
            PlayerPrefs.SetString("Name2", PlayerPrefs.GetString("Name1"));
            Names[1].text = PlayerPrefs.GetString("Name2", "AstronFan");
            Names[2].text = PlayerPrefs.GetString("Name3", "AstronFan");

            PlayerPrefs.SetString("Name1", Name);
            Names[0].text = Name;

            //Actualizar scores
            PlayerPrefs.SetFloat("Score3", PlayerPrefs.GetFloat("Score2"));
            PlayerPrefs.SetFloat("Score2", PlayerPrefs.GetFloat("Score1"));
            Scores[1].text = PlayerPrefs.GetFloat("Score2", 0f).ToString("N0");
            Scores[2].text = PlayerPrefs.GetFloat("Score3", 0f).ToString("N0");

            float score = FindObjectOfType<Manager>().score;
            PlayerPrefs.SetFloat("Score1", score);
            Scores[0].text = score.ToString("N0");

        }
        else if (NamePos == 2)
        {
            //Actualizar nombres
            PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
            Names[2].text = PlayerPrefs.GetString("Name3", "AstronFan");

            PlayerPrefs.SetString("Name2", Name);
            Names[1].text = Name;

            //Actualizar scores
            PlayerPrefs.SetFloat("Score3", PlayerPrefs.GetFloat("Score2"));
            Scores[2].text = PlayerPrefs.GetFloat("Score3", 0f).ToString("N0");

            float score = FindObjectOfType<Manager>().score;
            PlayerPrefs.SetFloat("Score2", score);
            Scores[1].text = score.ToString("N0");

            PlayerPrefs.SetString("Name2", Name);
            Names[1].text = Name;
        }
        else if (NamePos == 3)
        {
            float score = FindObjectOfType<Manager>().score;
            PlayerPrefs.SetFloat("Score3", score);
            Scores[2].text = score.ToString("N0");

            PlayerPrefs.SetString("Name3", Name);
            Names[2].text = Name;
        }
    }

    public void OkButton()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void PlayButton()
    {
        FindObjectOfType<AudioManager>().Play("UpgradeTaken");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ClicSound()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void ResetButton()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        //Default values
        PlayerPrefs.SetFloat("Score1", 0f);
        PlayerPrefs.SetFloat("Score2", 0f);
        PlayerPrefs.SetFloat("Score3", 0f);
        PlayerPrefs.SetString("Name1", "AstronFan");
        PlayerPrefs.SetString("Name2", "AstronFan");
        PlayerPrefs.SetString("Name3", "AstronFan");

        Scores[0].text = PlayerPrefs.GetFloat("Score1", 0f).ToString("N0");
        Scores[1].text = PlayerPrefs.GetFloat("Score2", 0f).ToString("N0");
        Scores[2].text = PlayerPrefs.GetFloat("Score3", 0f).ToString("N0");

        Names[0].text = PlayerPrefs.GetString("Name1", "AstronFan");
        Names[1].text = PlayerPrefs.GetString("Name2", "AstronFan");
        Names[2].text = PlayerPrefs.GetString("Name3", "AstronFan");
    }
}

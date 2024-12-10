using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLost : MonoBehaviour
{
    public GameObject YouLostUI;
    public TextMeshProUGUI finalscore;

    public void GGman()
    {
        float score = FindObjectOfType<Manager>().score;
        FinalScore(score);

        YouLostUI.SetActive(true);
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("UpgradeTaken");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        Debug.Log("Quiting");
        Application.Quit();
    }

    public void FinalScore(float score)
    {
        finalscore.text = "S C O R E : " + score.ToString("N0");
    }
}

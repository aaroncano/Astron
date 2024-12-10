using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer Mixer;
 

    private void Start()
    {
        //Ajustes previos
        Mixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("VolumeAudio", 1f)) * 20);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityConfig", 2));
        if (PlayerPrefs.GetInt("FSConfig", 0) == 1) Screen.fullScreen = true;
        if (PlayerPrefs.GetInt("FSConfig", 0) == 0) Screen.fullScreen = false;
    }


    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("UpgradeTaken");
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        ClicSound();
    }

    public void QuitGame()
    {
        ClicSound();
        Application.Quit();
    }

    public void ClicSound()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }
}

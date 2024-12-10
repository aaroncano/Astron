using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer Mixer;

    public Slider AudioSlider;
    public TMP_Dropdown QualityDropdown;
    public TMP_Dropdown ResolutionDropdown;
    public Toggle FullscreenToggle;

    Resolution[] resolutions;

    private void Start()
    {
        //Mostrar valores pasados de ajustes
        AudioSlider.value = PlayerPrefs.GetFloat("VolumeAudio", 1f);
        QualityDropdown.value = PlayerPrefs.GetInt("QualityConfig", 2);
        FullscreenToggle.isOn = FSisOnConverter();

        //Ajuste de resoluciones disponibles
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentRes = 0;
        for (int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentRes = i;
            }
        }
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentRes;
        ResolutionDropdown.RefreshShownValue();
    }

    public void VolumeSlider(float volume)
    {
        PlayerPrefs.SetFloat("VolumeAudio", volume);
        Mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void GraphicsSelection(int x)
    {
        PlayerPrefs.SetInt("QualityConfig", x);
        QualitySettings.SetQualityLevel(x);
    }

    public void FullscreenSet(bool x)
    {
        if (x == true) PlayerPrefs.SetInt("FSConfig", 1);
        if (x == false) PlayerPrefs.SetInt("FSConfig", 0);
        Screen.fullScreen = x;
    }

    public void ResolutionSelection(int x)
    {
        Resolution res = resolutions[x];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void Cliclsound()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }

    private bool FSisOnConverter()
    {
        if (PlayerPrefs.GetInt("FSConfig", 0) == 1) return true;
        else return false;
    }

}

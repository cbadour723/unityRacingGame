using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
    public SceneManager SceneManager;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public TMP_Dropdown qualityDropdown;


    private void Start()
    {
        LoadSettings();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
      
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQualtiy (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void GotoMainMenu()
    {
        // Load the scene with the name "MainMenu"
        // Make sure you have added the "MainMenu" scene in the build settings
        PlayerPrefs.SetInt("Fullscreen", Screen.fullScreen ? 1 : 0);
        PlayerPrefs.SetInt("QualityLevel", QualitySettings.GetQualityLevel());
        PlayerPrefs.Save();
        Debug.Log("hi");
        SceneManager.LoadScene("MainMenu2");

    }

    private void LoadSettings()
    {
        Debug.Log("hello");
        if (PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            SetVolume(volume);
            volumeSlider.value = volume;
        }

        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            bool isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
            SetFullscreen(isFullscreen);
            fullscreenToggle.isOn = isFullscreen;
        }

        if (PlayerPrefs.HasKey("QualityLevel"))
        {
            int qualityIndex = PlayerPrefs.GetInt("QualityLevel");
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityDropdown.value = qualityIndex;
        }
    }


}

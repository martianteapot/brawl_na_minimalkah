using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuControl : MonoBehaviour
{
    public AudioMixer audioMixer;
            
    public void StartGame()
    {
        SceneManager.LoadScene(1);        
    }

    public void Exit()
    {
        Application.Quit();     
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
}

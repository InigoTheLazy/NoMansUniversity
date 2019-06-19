using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Text musicButtonText, soundButtonText;
    private float mutedVolume = 0;

    void Start()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("WalkingScene");
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        audioMixer.GetFloat("volume", out float vol);

        if (vol > -80)
            soundButtonText.text = "sound on";
        else
            soundButtonText.text = "sound off";
    }

    public void ToggleSound()
    {
        audioMixer.GetFloat("volume", out float vol);

        if (vol > -80)
        {
            SetVolume(-80);
            mutedVolume = vol;
            soundButtonText.text = "sound off";
        }
        else
        {
            SetVolume(mutedVolume);
            soundButtonText.text = "sound on";
        }

    }

    public void ToggleMusic()
    {
        audioMixer.GetFloat("musicVolume", out float vol);

        if (vol > -80)
        {
            audioMixer.SetFloat("musicVolume", -80);
            musicButtonText.text = "music off";

        }
        else
        {
            audioMixer.SetFloat("musicVolume", 0);
            musicButtonText.text = "music on";
        }
    }
}

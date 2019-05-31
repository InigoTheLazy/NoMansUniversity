using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Button VolumeButton;

    void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("WalkingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        //float[] volumes = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        //float SelectedVolume = 100;

        //audioMixer.SetFloat("volume", volume);

        float volume;
        audioMixer.GetFloat("volume", out volume);

        Debug.Log("Volume: " + volume);
    }

    public void ToggleSound()
    {

    }

    public void ToggleMusic()
    {

    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Text musicButtonText, soundButtonText;
    private float masterVolume, musicVolume, mutedVolume = 0;

    private void Start()
    {
        audioMixer.GetFloat("masterVolume", out masterVolume);
        audioMixer.GetFloat("musicVolume", out musicVolume);

        if (masterVolume > -80)
        {
            soundButtonText.text = "sound on";
            volumeSlider.value = 0;
        }
        else
        {
            soundButtonText.text = "sound off";
            volumeSlider.value = -80;
        }

        if (musicVolume > -80)
            musicButtonText.text = "music on";
        else
            musicButtonText.text = "music off";
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
        audioMixer.GetFloat("masterVolume", out masterVolume);

        if (masterVolume > -80)
            soundButtonText.text = "sound on";
        else
            soundButtonText.text = "sound off";
    }

    public void ToggleSound()
    {
        audioMixer.GetFloat("masterVolume", out masterVolume);

        if (masterVolume > -80)
        {
            mutedVolume = masterVolume;
            SetVolume(-80);
            volumeSlider.value = -80;
            soundButtonText.text = "sound off";
        }
        else
        {
            SetVolume(mutedVolume);
            volumeSlider.value = mutedVolume;
            soundButtonText.text = "sound on";
        }
    }

    public void ToggleMusic()
    {
        audioMixer.GetFloat("musicVolume", out musicVolume);

        if (musicVolume > -80)
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

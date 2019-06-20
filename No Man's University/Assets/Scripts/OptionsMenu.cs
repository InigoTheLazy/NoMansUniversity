using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Text resolutionLabel;
    public Text graphicsLabel;
    public Text fullscreenLabel;

    Resolution[] resolutions;
    int currentResolutionIndex;
    private int qualityIndex;

    int defaultResolutionIndex;
    int defaultQualityIndex;
    bool defaultFullscreen;

    void Start()
    {
        resolutions = Screen.resolutions;
        currentResolutionIndex = GetCurrentResolution();
        qualityIndex = QualitySettings.GetQualityLevel();
    }

    void Update()
    {
        ShowResolution();
        ShowCurrentGraphics();
        ShowIfIsFullscreen();
    }

    private int GetCurrentResolution()
    {
        int current = 0;

        for (int i = 0; i < resolutions.Length; i++)
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                current = i;

        return current;
    }

    public void IncreaseResolution()
    {
        if (currentResolutionIndex < resolutions.Length - 1)
            currentResolutionIndex++;
        else
            currentResolutionIndex = 0;

        SetResolution();
    }

    private void SetResolution()
    {
        Resolution resolution = resolutions[currentResolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void IncreaseQuality()
    {
        if (qualityIndex < QualitySettings.names.Length - 1)
            qualityIndex++;
        else
            qualityIndex = 0;

        SetQuality();
    }

    private void SetQuality()
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen()
    {
        if (Screen.fullScreen)
            Screen.fullScreen = false;
        else
            Screen.fullScreen = true;
    }

    private void ShowResolution()
    {
        //resolutionLabel.text = Screen.width + " x " + Screen.height + " @ " + Screen.currentResolution.refreshRate + " Hz";

        resolutionLabel.text = resolutions[currentResolutionIndex].ToString();
    }

    private void ShowCurrentGraphics()
    {
        graphicsLabel.text = QualitySettings.names[QualitySettings.GetQualityLevel()].ToLower();
    }

    private void ShowIfIsFullscreen()
    {
        if (Screen.fullScreen)
            fullscreenLabel.text = "on";
        else
            fullscreenLabel.text = "off";
    }
}

using UnityEngine;

public class CharacterStatsScreen : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject characterMenuCanvas;

    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        characterMenuCanvas.SetActive(false);
    }

    void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        characterMenuCanvas.SetActive(true);
    }
}

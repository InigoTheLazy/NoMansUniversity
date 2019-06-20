using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu, startMenu, options, about;

    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        pauseMenu.SetActive(false);
    }

    void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

        if (startMenu.active != true)
            startMenu.SetActive(true);
        if (options.active != false)
            options.SetActive(false);
        if (about.active != false)
            about.SetActive(false);
    }
}

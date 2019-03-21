using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuCanvas;
    
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
        pauseMenuCanvas.SetActive(false);
    }

    void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
    }
}

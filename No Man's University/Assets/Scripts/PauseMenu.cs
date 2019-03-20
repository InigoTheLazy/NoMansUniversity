using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        SceneManager.LoadScene("WalkingScene");
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        SceneManager.LoadSceneAsync("PauseMenuScene");
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}

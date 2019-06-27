using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuCanvas, selectGame, options;

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
        if (pauseMenuCanvas)
            pauseMenuCanvas.SetActive(false);
    }

    void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);

        if (selectGame.active != true)
            selectGame.SetActive(true);
        if (options.active != false)
            options.SetActive(false);
    }

    public void SavePlayerData()
    {
        GameObject.Find("PlayerGM(Clone)").GetComponent<PlayerData>().SavePlayerData();
    }

    public void ShowMainMenu()
    {
        GameObject playerGM;
        GameObject music;

        if (playerGM = GameObject.Find("PlayerGM(Clone)"))
            GameObject.Destroy(playerGM);

        if (music = GameObject.Find("BackgroundMusic"))
            GameObject.Destroy(music);

        SceneManager.LoadScene("MainMenu");
    }
}

using UnityEngine;
﻿using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerStatsData;
    
    public void NewGame()
    {
        playerStatsData.GetComponent<PlayerData>().CreateBaseStats();
        Instantiate(playerStatsData);
        SceneManager.LoadScene("WalkingScene");
    }

    public void ResumeGame()
    {
        playerStatsData.GetComponent<PlayerData>().LoadPlayerData();
        Instantiate(playerStatsData);
        SceneManager.LoadScene("WalkingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

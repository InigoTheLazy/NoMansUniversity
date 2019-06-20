using UnityEngine;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerStatsData;

    public void PlayGame()
    {
        playerStatsData.GetComponent<PlayerData>().CreateBaseStats();
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene("WalkingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerStatsData;

    public void PlayGame()
    {

        playerStatsData.GetComponent<PlayerData>().CreateBaseStats();
        //SceneManager.LoadScene("WalkingScene");
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}

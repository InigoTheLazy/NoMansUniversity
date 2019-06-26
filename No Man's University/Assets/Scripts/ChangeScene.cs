using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string startPoint;
    public string exitPoint;
    public string levelName;
    private Player thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
            thePlayer.startPoint = exitPoint;
        }
    }
}

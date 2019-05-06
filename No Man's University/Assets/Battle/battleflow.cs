using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class battleflow : MonoBehaviour
{
    public static int whichturn = 1;
    public static float currentDamage = 0;

    public static string damageDisplay = "n";
    public static string enemyDefeated = "n";

    void Start()
    {
        
    }

    void Update()
    {
        if (enemyDefeated == "y")
        {
            SceneManager.LoadScene("WalkingScene");
            enemyDefeated = "n";
        }
    }

    public void Run ()
    {
        SceneManager.LoadScene("WalkingScene");
    }
}

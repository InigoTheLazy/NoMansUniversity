using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class battleflow : MonoBehaviour
{
    public static int whichturn = 1;
    public static float currentDamage = 0;

    public static string damageDisplay = "n";
    public static string enemyDefeated = "n";

    public GameObject combatChoiceBox;
    public GameObject cursor;
    public GameObject combatInfoText;
    public GameObject activeLetter;

    public bool initiateDeflect;

    void Start()
    {
        initiateDeflect = true;
    }

    void Update()
    {
        if (enemyDefeated == "y")
        {
            SceneManager.LoadScene("WalkingScene");
            enemyDefeated = "n";
        }

        if (whichturn == 0 || whichturn == 2)
        {
            ShowPanel(false);
            if (initiateDeflect)
                DamageDecreaseAttempt();
        }
        else
        {
            ShowPanel(true);
            initiateDeflect = true;
        }

    }

    public void ShowPanel(bool tf)
    {
        combatChoiceBox.SetActive(tf);
        cursor.SetActive(tf);
        combatInfoText.SetActive(tf);
    }

    public void Run ()
    {
        SceneManager.LoadScene("WalkingScene");
    }

    private void DamageDecreaseAttempt()
    {
        initiateDeflect = false;
        int randomNumber = Random.Range(0, 3);
        switch (randomNumber)
        {
            case 0:
                DecreaseWASD('a');
                break;
            case 1:
                DecreaseWASD('s');
                break;
            case 2:
                DecreaseWASD('d');
                break;
            case 3:
                DecreaseWASD('w');
                break;
        }
    }

    private void DecreaseWASD(char letter)
    {
        testSubject.SetActive(true);
        Invoke();

    }

    private void EnableLetter(char letter)
    {

    }
    
}

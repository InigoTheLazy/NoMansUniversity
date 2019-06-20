using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class battleflow : MonoBehaviour
{
    public static int whichturn = 1;
    public static float currentDamage = 0;

    public static string damageDisplay = "n";
    public static string enemyDefeated = "n";

    public GameObject combatChoiceBox;
    public GameObject cursor;
    public GameObject combatInfoText;
    public GameObject enemyCharacter;
    private bool defendYourself = false;
    private char defendLetter;

    [SerializeField]
    private GameObject letterA;
    [SerializeField]
    private GameObject letterD;
    [SerializeField]
    private GameObject letterS;
    [SerializeField]
    private GameObject letterW;
    public bool initiateDeflect;

    void Start()
    {
        initiateDeflect = true;
    }

    void Update()
    {
        if (enemyDefeated == "y")
        {
            GameObject.Find("Hero").GetComponent<herocon>().strengthPotionOn = false;
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

        if (defendYourself)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (letterA.gameObject.activeSelf)
                {
                    SuccesfulDefense();
                }
                else
                {
                    FailedDefense();
                }
            }
    
            else if (Input.GetKey(KeyCode.D))
            {
                if (letterD.gameObject.activeSelf)
                {
                    SuccesfulDefense();
                }
                else
                {
                    FailedDefense();
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (letterS.gameObject.activeSelf)
                {
                    SuccesfulDefense();
                }
                else
                {
                    FailedDefense();
                }
            }
            else if(Input.GetKey(KeyCode.W))
            {
                if (letterW.gameObject.activeSelf)
                {
                    SuccesfulDefense();
                }
                else
                {
                    FailedDefense();
                }
            }
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
                    DecreaseWASD(letterA);
                    defendLetter = 'a';
                    break;
                case 1:
                    DecreaseWASD(letterD);
                    defendLetter = 'd';
                    break;
                case 2:
                    DecreaseWASD(letterS);
                    defendLetter = 's';
                    break;
                case 3:
                    DecreaseWASD(letterW);
                    defendLetter = 'w';
                    break;
            }
    }

    private void DecreaseWASD(GameObject letter)
    {
        letter.SetActive(true);
        EnableLetter(letter);
    }

    private void EnableLetter(GameObject letter)
    {
        TurnOffAllLetters();
        letter.SetActive(true);
        defendYourself = true;
        Invoke("NoMoreDefending", 1f);


        Invoke("TurnOffAllLetters", 1f);
    }

    private void TurnOffAllLetters()
    {
        letterA.SetActive(false);
        letterD.SetActive(false);
        letterS.SetActive(false);
        letterW.SetActive(false);
    }
    
    private void NoMoreDefending()
    {
        defendYourself = false;
    }

    private void SuccesfulDefense()
    {
        enemyCharacter.GetComponent<enemycon>().damageMultiplier = 10;
    }

    private void FailedDefense()
    {
        enemyCharacter.GetComponent<enemycon>().damageMultiplier = 0;
    }

}

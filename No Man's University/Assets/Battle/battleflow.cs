using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class battleflow : MonoBehaviour
{
    public static int whichturn = 1;
    public static float currentDamage = 0;
    public static float damageMultiplier = 1;

    public static string damageDisplay = "n";
    public static string enemyDefeated = "n";
    public static int enemyNumber = 0;
    public static float armor;

    public GameObject combatChoiceBox;
    public GameObject cursor;
    public GameObject combatInfoText;
    public GameObject enemyCharacter;
    public GameObject walkingPlayer;
    public GameObject playerStats;
    public GameObject CanvasObject;
    public GameObject CombatUI;
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

    private DialogueManager dMAn;

    void Start()
    {
        playerStats = GameObject.Find("PlayerGM(Clone)");
        armor = playerStats.GetComponent<PlayerData>().armor;
        walkingPlayer = GameObject.Find("Player");
        initiateDeflect = true;
        dMAn = FindObjectOfType<DialogueManager>();
        
    }

    void Update()
    {
        if (enemyDefeated == "y")
        {
            VictoryScreen();
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
        this.gameObject.GetComponent<BattleVideos>().PlayVideo("Assets/Battle/Videos/i_am_speed.mp4", 4);

        Invoke("Run2", 3);
    }

    private void Run2()
    {
        SceneManager.LoadScene("WalkingScenev3");
        walkingPlayer.SetActive(true);
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
        Invoke("NoMoreDefending", 10f);


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
        FailedDefense();
    }

    private void SuccesfulDefense()
    {
        damageMultiplier = 0.5f;
    }

    private void FailedDefense()
    {
        damageMultiplier = 1;
    }

    public void VictoryScreen ()
    {
        string scene = "";
        int coins = 0;
        int exp = 0;
        GameObject.Find("generic_character_1 1").GetComponent<herocon>().strengthPotionOn = false;
        switch (enemyNumber)
        {
            case 0:
                scene = "WalkingScenev2";
                coins = 10;
                exp = 100;
                break;
            case 1:
                scene = "WalkingScenev4";
                coins = 50;
                exp = 250;
                break;
            case 2:
                scene = "WalkingScenev4";
                coins = 250;
                exp = 1000;
                break;
        }
        CanvasObject.SetActive(false);
        ShowPanel(false);
        CombatUI.SetActive(false);
        dMAn.ShowBox("You found " + coins.ToString() + " coins. \nYou got " + exp.ToString() + " experience points.");
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            dMAn.DisableBox();
            SceneManager.LoadScene(scene);
            enemyDefeated = "n";
            whichturn = 1;
            walkingPlayer.SetActive(true);
            playerStats.GetComponent<PlayerData>().coins += coins;
            playerStats.GetComponent<PlayerData>().experience += exp;
        }
    }

}

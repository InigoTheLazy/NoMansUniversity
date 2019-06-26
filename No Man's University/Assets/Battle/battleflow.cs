using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


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

    public void Run()
    {
        GameObject.Find("HUD").SetActive(false);
        GameObject.Find("CombatDialogueBox").SetActive(false);
        gameObject.GetComponents<VideoPlayer>()[0].Play();
        Invoke("Run2", 3);
    }

    public void Die()
    {
        GameObject.Find("HUD").SetActive(false);
        GameObject.Find("CombatDialogueBox").SetActive(false);
        gameObject.GetComponents<VideoPlayer>()[1].Play();
        Invoke("Die2", 4);
    }

    public void Die2()
    {
        walkingPlayer.SetActive(true);
        SceneManager.LoadScene("WalkingScene");
    }

    private void Run2()
    {
        SceneManager.LoadScene("WalkingScenev3");
        walkingPlayer.SetActive(true);
    }

    private void DamageDecreaseAttempt()
    {
        
        initiateDeflect = false;


            int randomNumber = Random.Range(0, 4);
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
        ChangeColor("white");
        TurnOffAllLetters();
        letter.SetActive(true);
        defendYourself = true;
        //Invoke("NoMoreDefending", 10f);


        Invoke("TurnOffAllLetters", 2f);
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
        ChangeColor("green");
        damageMultiplier = 0.5f;
    }

    private void FailedDefense()
    {
        ChangeColor("red");
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
                scene = "CreditsScene";
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

    public void ChangeColor(string color)
    {
        switch(color)
        {
            case "green":
                letterA.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                letterD.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                letterS.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                letterW.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case "red":
                letterA.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                letterD.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                letterS.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                letterW.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case "white":
                letterA.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                letterD.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                letterS.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                letterW.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                damageMultiplier = 1;
                break;
        }
    }

}

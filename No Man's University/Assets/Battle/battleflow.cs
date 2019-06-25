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
        playerStats = GameObject.Find("PlayerGM(Clone)");
        armor = playerStats.GetComponent<PlayerData>().armor;
        walkingPlayer = GameObject.Find("Player");
        initiateDeflect = true;
    }

    void Update()
    {
        if (enemyDefeated == "y")
        {
            string scene = "";
            GameObject.Find("generic_character_1 1").GetComponent<herocon>().strengthPotionOn = false;
            switch (enemyNumber)
            {
                case 0:
                    playerStats.GetComponent<PlayerData>().coins += 10;
                    playerStats.GetComponent<PlayerData>().experience += 100;
                    scene = "WalkingScenev2";
                    break;
                case 1:
                    playerStats.GetComponent<PlayerData>().coins += 50;
                    playerStats.GetComponent<PlayerData>().experience += 250;
                    scene = "WalkingScenev4";
                    break;
                case 2:
                    playerStats.GetComponent<PlayerData>().coins += 250;
                    playerStats.GetComponent<PlayerData>().experience += 1000;
                    scene = "WalkingScenev4";
                    break;

            }
            SceneManager.LoadScene(scene);
            
            enemyDefeated = "n";
            whichturn = 1;
            walkingPlayer.SetActive(true);
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

}

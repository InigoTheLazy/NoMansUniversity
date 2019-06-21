using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class herocon : MonoBehaviour
{
    public static float heroHP;
    public int heroMaxHP;
    public int armor;
    public int str;
    public int dex;
    public Transform damTextObj;
    public Slider healthBar;
    public Text HPText;
    public Button button1;
    public GameObject playerStats;
    public GameObject walkingPlayer;
    public bool strengthPotionOn;
    private bool hasStrengthUsed;
    private bool usedLastTurn;
    private bool changeToFalse;

    void Awake()
    {
        walkingPlayer = GameObject.Find("Player");
        hasStrengthUsed = false;
        usedLastTurn = false;
        changeToFalse = false;
        FindStats();
    }

    void Update()
    {
        healthBar.maxValue = heroMaxHP;
        healthBar.value = heroHP;
        HPText.text = heroHP + "/" + heroMaxHP;

        if (heroHP <= 0)
        {
            walkingPlayer.SetActive(true);
            SceneManager.LoadScene("WalkingScene");
                
        }

        if (strengthPotionOn && !hasStrengthUsed)
        {
            str += 10;
            hasStrengthUsed = true;
        }

        if (battleflow.whichturn == 2)
        {
            strengthPotionOn = false;
        }


    }

    IEnumerator turnEnd()
    {
        battleflow.whichturn = 0;
        yield return new WaitForSeconds(4);
        battleflow.whichturn = 2;
        Instantiate(damTextObj, new Vector2(5.85f, 4.95f), damTextObj.rotation);
        battleflow.damageDisplay = "y";
        if (changeToFalse)
        {
            usedLastTurn = false;
            changeToFalse = false;
        }
    }

    public void attack1 ()
    {
        if (battleflow.whichturn == 1)
        {
            battleflow.currentDamage = 15 + (str * 3);
            GetComponent<Animator>().SetTrigger("heroAttack");
            strengthPotionOn = false;
            StartCoroutine(turnEnd());
        }
    }

    public void skill1 ()
    {
        if (usedLastTurn)
            changeToFalse = true;
        else
        {
            battleflow.currentDamage = 50 + (str * 5);
            GetComponent<Animator>().SetTrigger("heroSkill");
            strengthPotionOn = false;
            StartCoroutine(turnEnd());
            usedLastTurn = true;
        }
    }

    private void FindStats()
    {
        playerStats = GameObject.Find("PlayerGM(Clone)");
        heroMaxHP = playerStats.GetComponent<PlayerData>().hitPointsMax;
        heroHP = playerStats.GetComponent<PlayerData>().hitPointsCur;
        armor = playerStats.GetComponent<PlayerData>().armor;
        str = playerStats.GetComponent<PlayerData>().strStat;
        dex = playerStats.GetComponent<PlayerData>().dexStat;
    }

    public void AlterHP(float alterAmount)
    {
        if ((heroHP + alterAmount) > heroMaxHP)
            heroHP = heroMaxHP;
        else
            heroHP += alterAmount;
    }

}


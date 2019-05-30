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

    void Awake()
    {
        FindStats();
    }

    void Start()
    {
         
    }

    void Update()
    {
        healthBar.maxValue = heroMaxHP;
        healthBar.value = heroHP;
        HPText.text = heroHP + "/" + heroMaxHP;

        if (heroHP <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenuScene");
            heroHP = 100;
        }

    }

    IEnumerator turnEnd()
    {
        battleflow.whichturn = 0;
        yield return new WaitForSeconds(4);
        battleflow.whichturn = 2;
        Instantiate(damTextObj, new Vector2(5.85f, 4.95f), damTextObj.rotation);
        battleflow.damageDisplay = "y";
    }

    public void attack1 ()
    {
        if (battleflow.whichturn == 1)
        {
            battleflow.currentDamage = 15 + (str * 5);
            GetComponent<Animator>().SetTrigger("heroAttack");
            StartCoroutine(turnEnd());
        }
    }

    public void skill1 ()
    {
        battleflow.currentDamage = 50 + (str * 5);
        GetComponent<Animator>().SetTrigger("heroSkill");
        StartCoroutine(turnEnd());
    }

    private void FindStats()
    {
        playerStats = GameObject.Find("PlayerGM");
        heroMaxHP = playerStats.GetComponent<PlayerData>().hitPointsMax;
        heroHP = playerStats.GetComponent<PlayerData>().hitPointsCur;
        armor = playerStats.GetComponent<PlayerData>().armor;
        str = playerStats.GetComponent<PlayerData>().strStat;
        dex = playerStats.GetComponent<PlayerData>().dexStat;
    }

}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsTextScript : MonoBehaviour
{
    public int heroHP;
    public int heroMaxHP;
    public int armor;
    public int str;
    public int dex;
    public int con;
    public int gold;
    public int experience;

    public GameObject playerStats;
    public TextMeshProUGUI strStat;
    public TextMeshProUGUI consStat;
    public TextMeshProUGUI dexStat;
    public TextMeshProUGUI armorStat;
    public TextMeshProUGUI hpStat;
    public TextMeshProUGUI maxhpStat;
    public TextMeshProUGUI goldStat;
    public TextMeshProUGUI experienceStat;

    void Start()
    {
        FindStats();
    }

    void Update()
    {
        strStat.text = str.ToString();
        consStat.text = con.ToString();
        dexStat.text = dex.ToString();
        armorStat.text = armor.ToString();
        hpStat.text = heroHP.ToString();
        maxhpStat.text = heroMaxHP.ToString();
        goldStat.text = gold.ToString();
        experienceStat.text = experience.ToString();
    }

    private void FindStats()
    {
        playerStats = GameObject.Find("PlayerGM(Clone)");
        heroMaxHP = playerStats.GetComponent<PlayerData>().hitPointsMax;
        heroHP = playerStats.GetComponent<PlayerData>().hitPointsCur;
        armor = playerStats.GetComponent<PlayerData>().armor;
        str = playerStats.GetComponent<PlayerData>().strStat;
        dex = playerStats.GetComponent<PlayerData>().dexStat;
        con = playerStats.GetComponent<PlayerData>().conStat;
        gold = playerStats.GetComponent<PlayerData>().coins;
        experience = playerStats.GetComponent<PlayerData>().experience;
    }

    public void IncreaseStrength()
    {
        if (playerStats.GetComponent<PlayerData>().experience >= 100)
        {
            playerStats.GetComponent<PlayerData>().strStat++;
            playerStats.GetComponent<PlayerData>().experience -= 100;
            FindStats();
        }
    }


    public void IncreaseDexterity()
    {
        if (playerStats.GetComponent<PlayerData>().experience >= 100)
        {
            playerStats.GetComponent<PlayerData>().dexStat++;
            playerStats.GetComponent<PlayerData>().experience -= 100;
            FindStats();
        }
    }

    public void IncreaseConstitution()
    {
        if (playerStats.GetComponent<PlayerData>().experience >= 100)
        {
            playerStats.GetComponent<PlayerData>().conStat++;
            playerStats.GetComponent<PlayerData>().experience -= 100;
            FindStats();
        }
    }
}

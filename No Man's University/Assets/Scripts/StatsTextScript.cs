using System.Collections;
using System.Collections.Generic;
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

    public GameObject playerStats;
    public Text strStat;
    public Text consStat;
    public Text dexStat;
    public Text armorStat;
    public Text hpStat;
    public Text maxhpStat;

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
    }

    public void IncreaseStrength()
    {
        playerStats.GetComponent<PlayerData>().strStat++;
        FindStats();
    }

    public void IncreaseDexterity()
    {
        playerStats.GetComponent<PlayerData>().dexStat++;
        FindStats();
    }

    public void IncreaseConstitution()
    {
        playerStats.GetComponent<PlayerData>().conStat++;
        FindStats();
    }
}

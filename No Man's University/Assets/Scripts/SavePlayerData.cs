using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayerData
{
    public string uniquePlayerName;
    public int strStat;
    public int conStat;
    public int dexStat;
    public int armor;
    public int hitPointsMax;
    public int hitPointsCur;
    public int coins;
    public int experience;

    public bool slot1, slot2, slot3, slot4, slot5, slot6;

    public SavePlayerData(PlayerData player)
    {
        uniquePlayerName = player.uniquePlayerName;
        strStat = player.strStat;
        conStat = player.conStat;
        dexStat = player.dexStat;
        armor = player.armor;
        hitPointsMax = player.hitPointsMax;
        hitPointsCur = player.hitPointsCur;
        coins = player.coins;
        experience = player.experience;
        slot1 = player.slot1;
        slot2 = player.slot2;
        slot3 = player.slot3;
        slot4 = player.slot4;
        slot5 = player.slot5;
        slot6 = player.slot6;
    }
}

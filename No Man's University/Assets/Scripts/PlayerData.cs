using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
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

    public PlayerData(Player player)
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

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        hitPointsMax = 50 + (conStat * 10);
        hitPointsCur = hitPointsMax;
        armor = 10 + dexStat * 5;
    }

    public void CreateBaseStats()
    {
        uniquePlayerName = "Filler";
        strStat = 5;
        conStat = 5;
        dexStat = 5;
        armor = 10 + dexStat * 5;
        hitPointsMax = 50 + (conStat * 10);
        hitPointsCur = hitPointsMax;
        coins = 50;
        experience = 0;
        slot1 = false;
        slot2 = false;
        slot3 = false;
        slot4 = false;
        slot5 = false;
        slot6 = false;
    }

    public void PotionBought(int pot, int price)
    {
        switch(pot)
        {
            case 1:
                slot1 = true;
                break;
            case 2:
                slot2 = true;
                break;
            case 3:
                slot3 = true;
                break;
            case 4:
                slot4 = true;
                break;
            case 5:
                slot5 = true;
                break;
            case 6:
                slot6 = true;
                break;
        }

        coins -= price;
    }
}

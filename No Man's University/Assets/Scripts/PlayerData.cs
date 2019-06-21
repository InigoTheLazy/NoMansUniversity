using UnityEngine;

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

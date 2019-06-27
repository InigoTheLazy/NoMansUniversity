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

    public void SavePlayerData()
    {
        SaveSystem.SavePlayerData(this);
    }

    public void LoadPlayerData()
    {
        SavePlayerData data = SaveSystem.LoadPlayerData();

        uniquePlayerName = data.uniquePlayerName;
        strStat = data.strStat;
        conStat = data.conStat;
        dexStat = data.dexStat;
        armor = data.armor;
        hitPointsMax = data.hitPointsMax;
        hitPointsCur = data.hitPointsCur;
        coins = data.coins;
        experience = data.experience;
        slot1 = data.slot1;
        slot2 = data.slot2;
        slot3 = data.slot3;
        slot4 = data.slot4;
        slot5 = data.slot5;
        slot6 = data.slot6;
    }
}

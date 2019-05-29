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

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        hitPointsMax = 50 + (conStat * 10);
        hitPointsCur = hitPointsMax;
    }

    public void CreateBaseStats()
    {
        Instantiate(this.gameObject);
        uniquePlayerName = "Filler";
        strStat = 5;
        conStat = 5;
        dexStat = 5;
        armor = 20;
        hitPointsMax = 50 + (conStat * 10);
        hitPointsCur = hitPointsMax;
    }
}
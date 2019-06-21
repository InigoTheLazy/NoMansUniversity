using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;
    public GameObject BGM;
    private GameObject PlayerGO;
    

    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    public GameObject weapon;
    

    public Component enemyconScript;

    void Start()
    {
    }

    public void Update()
    {
        if (equipped)
        {
            // perform weapon acts here
        }
    }

    public void ItemUsage(GameObject player, GameObject enemy, Transform damTextObj)
    {
        PlayerGO = player;
        if (type == "weapon")
        {
            equipped = true;
        }

        else if (type == "potion")
        {
            equipped = false;
            switch (ID)
            {
                case 1:
                     player.gameObject.GetComponent<herocon>().AlterHP(50);
                     break;
                case 2:
                    player.gameObject.GetComponent<herocon>().AlterHP(200);
                    break;
                case 3:
                    player.gameObject.GetComponent<herocon>().strengthPotionOn = true;
                    break;
                case 4:
                    battleflow.currentDamage = 100;
                    Instantiate(damTextObj, new Vector2(5.85f, 4.95f), damTextObj.rotation);
                    battleflow.damageDisplay = "y";
                    break;
                case 5:
                    BGM = GameObject.Find("Battle_Game_Master");
                    BGM.gameObject.GetComponent<BattleVideos>().PlayVideo("Assets/Battle/Videos/makumba_death.mp4", 6);
                    Invoke("Die", 6);
                    break;
                case 6:
                    BGM = GameObject.Find("Battle_Game_Master");
                    BGM.gameObject.GetComponent<BattleVideos>().PlayVideo("Assets/Battle/Videos/potion_empty.mp4", 6);
                    break;
            }
        }
    }

    private void Die()
    {
        PlayerGO.gameObject.GetComponent<herocon>().AlterHP(-PlayerGO.gameObject.GetComponent<herocon>().heroMaxHP);
    }
}

using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    public GameObject weapon;

    public void Update()
    {
        if (equipped)
        {
            // perform weapon acts here
        }
    }

    public void ItemUsage(GameObject player, GameObject enemy)
    {
        if (type == "weapon")
        {
            equipped = true;
        }

        else if (type == "potion")
        {
            Debug.Log(ID);
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
                    enemy.gameObject.GetComponent<enemycon>().enemyHP -= 100f;
                    break;
                case 5:
                    player.gameObject.GetComponent<herocon>().AlterHP(player.gameObject.GetComponent<herocon>().heroMaxHP);
                    break;
                case 6:
                    break;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Video;

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

    public void ItemUsage(GameObject player, GameObject enemy, Transform damTextObj, Transform particle)
    {
        PlayerGO = player;
        if (type == "weapon")
        {
            equipped = true;
        }

        else if (type == "potion")
        {
            Vector3 playerpos = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 3, player.gameObject.transform.position.z);
            Vector3 enemypos = new Vector3(enemy.gameObject.transform.position.x, enemy.gameObject.transform.position.y + 3, enemy.gameObject.transform.position.z);
            equipped = false;
            
            switch (ID)
            {
                case 1:
                    player.gameObject.GetComponent<herocon>().AlterHP(50);
                    Instantiate(particle, playerpos, particle.rotation);
                    break;
                case 2:
                    player.gameObject.GetComponent<herocon>().AlterHP(200);
                    Instantiate(particle, playerpos, particle.rotation);
                    break;
                case 3:
                    player.gameObject.GetComponent<herocon>().strengthPotionOn = true;
                    Instantiate(particle, playerpos, particle.rotation);
                    break;
                case 4:
                    battleflow.currentDamage = 100;
                    Instantiate(damTextObj, new Vector2(5.85f, 4.95f), damTextObj.rotation);
                    battleflow.damageDisplay = "y";
                    Instantiate(particle, enemypos, particle.rotation);
                    break;
                case 5:
                    BGM = GameObject.Find("Battle_Game_Master");
                    GameObject.Find("HUD").SetActive(false);
                    GameObject.Find("CombatDialogueBox").SetActive(false);
                    BGM.GetComponents<VideoPlayer>()[2].Play();
                    Invoke("Die", 6);
                    break;
                case 6:
                    BGM = GameObject.Find("Battle_Game_Master");
                    GameObject.Find("HUD").SetActive(false);
                    GameObject.Find("CombatDialogueBox").SetActive(false);
                    BGM.GetComponents<VideoPlayer>()[3].Play();
                    break;
            }
        }
    }

    private void Die()
    {
        BGM = GameObject.Find("Battle_Game_Master");
        BGM.gameObject.GetComponent<battleflow>().Die2();
    }
}

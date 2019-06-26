using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGO;
    public Transform damTextObj;
    public GameObject infoBox;
    public Transform particle;

    public bool slot1, slot2, slot3, slot4, slot5, slot6;

    public GameObject playerStats;
    public GameObject Player;
    public GameObject Enemy;
    private GameObject potionPrefab;
    public bool hasBeenUsed;
    public bool playersObject;

    void Start()
    {
        FindStats();
        playerStats = GameObject.Find("PlayerGM(Clone)");
        Player = GameObject.Find("generic_character_1 1");
        hasBeenUsed = false;
        playersObject = false;
        slotIconGO = transform.GetChild(0);
        UpdateSlot(false);

        if (this.gameObject.name == "Slot1" && slot1)
        {
            item = Resources.Load("red potion") as GameObject;
            playersObject = true;
            UpdateSlot(slot1);
        }
        else if (this.gameObject.name == "Slot2" && slot2)
        {
            item = Resources.Load("brown potion") as GameObject;
            playersObject = true;
            UpdateSlot(slot2);
        }
        else if (this.gameObject.name == "Slot3" && slot3)
        {
            item = Resources.Load("purple potion") as GameObject;
            playersObject = true;
            UpdateSlot(slot3);
        }
        else if (this.gameObject.name == "Slot4" && slot4)
        {
            item = Resources.Load("yellow potion") as GameObject;
            playersObject = true;
            UpdateSlot(slot4);
        }
        else if (this.gameObject.name == "Slot5" && slot5)
        {
            item = Resources.Load("green potion") as GameObject;
            playersObject = true;
            UpdateSlot(slot5);
        }
        else if (this.gameObject.name == "Slot6" && slot6)
        {
            item = Resources.Load("blue potion") as GameObject;
            playersObject = true;
            UpdateSlot(slot6);
        }

        Enemy = GameObject.Find("Enemy");
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!hasBeenUsed && playersObject)
        {
            UseItem();
            hasBeenUsed = true;
            slotIconGO.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
        }
    }

    public void UpdateSlot(bool tf)
    {
        if (tf)
            slotIconGO.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        
        else
            slotIconGO.GetComponent<Image>().color = new Color32(0, 0, 0, 100);

    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage(Player, Enemy, damTextObj, particle);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        infoBox.GetComponent<Text>().text = description;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        infoBox.GetComponent<Text>().text = "";
    }

    public void FindStats()
    {
        playerStats = GameObject.Find("PlayerGM(Clone)");
        slot1 = playerStats.GetComponent<PlayerData>().slot1;
        slot2 = playerStats.GetComponent<PlayerData>().slot2;
        slot3 = playerStats.GetComponent<PlayerData>().slot3;
        slot4 = playerStats.GetComponent<PlayerData>().slot4;
        slot5 = playerStats.GetComponent<PlayerData>().slot5;
        slot6 = playerStats.GetComponent<PlayerData>().slot6;
    }
}

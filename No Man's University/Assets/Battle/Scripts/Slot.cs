using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{

    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGO;

    public GameObject Player;
    public GameObject Enemy;
    private GameObject potionPrefab;

    public bool hasBeenUsed;
    public bool playersObject;

    void Start()
    {
        hasBeenUsed = false;
        playersObject = true;
        if (this.gameObject.name == "Slot1")
            item = Resources.Load("red potion") as GameObject;
        else if (this.gameObject.name == "Slot2")
            item = Resources.Load("brown potion") as GameObject;
        else if (this.gameObject.name == "Slot3")
            item = Resources.Load("purple potion") as GameObject;
        else if (this.gameObject.name == "Slot4")
            item = Resources.Load("yellow potion") as GameObject;
        else if (this.gameObject.name == "Slot5")
            item = Resources.Load("green potion") as GameObject;
        else if (this.gameObject.name == "Slot6")
            item = Resources.Load("blue potion") as GameObject;

        Enemy = GameObject.Find("Enemy");

        slotIconGO = transform.GetChild(0);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!hasBeenUsed && playersObject)
        {
            UseItem();
            hasBeenUsed = true;
        }
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage(Player, Enemy);
    }

}

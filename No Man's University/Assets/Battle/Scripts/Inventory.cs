using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;
    public GameObject InventoryPanel;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject itemInfo;
    public GameObject slotHolder;

    void Start()
    {
        allSlots = 6;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
                
            if (slot[i].GetComponent<Slot>().item = null)
                slot[i].GetComponent<Slot>().empty = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
            inventoryEnabled = false;

        if (inventoryEnabled)
        {
            this.gameObject.GetComponent<battleflow>().ShowPanel(false);
            InventoryPanel.SetActive(true);
            itemInfo.SetActive(true);
        }

        if (!inventoryEnabled)
        {
            this.gameObject.GetComponent<battleflow>().ShowPanel(true);

            InventoryPanel.SetActive(false);
            itemInfo.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    private void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {

                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot(false);
                slot[i].GetComponent<Slot>().empty = false;

                return;
            }

        }
    }

    public void ToCombatMenu()
    {
        inventoryEnabled = false;
    }
}

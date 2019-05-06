using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;

    public GameObject InventoryPanel;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;
    void Start()
    {
        inventoryEnabled = true;
        allSlots = 6;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            inventoryEnabled = false;

        if (inventoryEnabled)
        {
            InventoryPanel.SetActive(true);
        }

        if (!inventoryEnabled)
        {
            InventoryPanel.SetActive(false);
        }
    }
}

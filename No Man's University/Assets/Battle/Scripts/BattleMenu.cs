using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    public GameObject battleInventory;

    public GameObject combatMenu;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BattleItemMenu()
    {
        combatMenu.SetActive(false);
        battleInventory.GetComponent<Inventory>().inventoryEnabled = true;
    }
}

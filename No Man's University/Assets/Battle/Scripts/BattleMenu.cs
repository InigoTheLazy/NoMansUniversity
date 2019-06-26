using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    public GameObject battleInventory;

    public GameObject combatMenu;

    public void BattleItemMenu()
    {
        combatMenu.SetActive(false);
        battleInventory.GetComponent<Inventory>().inventoryEnabled = true;
    }
}

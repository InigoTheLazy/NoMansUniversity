using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    public GameObject battleInventory;

    public GameObject combatMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BattleItemMenu()
    {
        combatMenu.SetActive(false);
        battleInventory.GetComponent<Inventory>().inventoryEnabled = true;
    }
}

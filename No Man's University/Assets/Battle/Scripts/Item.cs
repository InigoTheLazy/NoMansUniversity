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

    public bool playersObject;

    public void Start()
    {
        if (!playersObject)
        {
            
        }
    }

    public void Update()
    {
        if (equipped)
        {
            // perform weapon acts here
        }
    }

    public void ItemUsage()
    {
        if (type == "weapon")
        {
            equipped = true;
        }

        else if (type == "potion")
        {
            equipped = false;
        }


    }
}

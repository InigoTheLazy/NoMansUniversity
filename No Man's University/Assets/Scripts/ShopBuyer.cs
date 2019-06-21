using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopBuyer : MonoBehaviour
{
    public string dialogue;
    public int price;
    public int slot;
    private DialogueManager ddMAn;
    private bool playerinzone;
    public GameObject playerStats;

    void Start()
    {
        playerStats = GameObject.Find("PlayerGM(Clone)");
        playerinzone = false;
        ddMAn = FindObjectOfType<DialogueManager>();
    }
    void Update()
    {
        if (playerinzone && Input.GetKeyDown(KeyCode.E))
        {
            switch (slot)
            {
                case 1:
                    if (playerStats.GetComponent<PlayerData>().slot1)
                        ddMAn.ShowBox("You already have this potion.");
                    else Check(price, slot);
                    break;
                case 2:
                    if (playerStats.GetComponent<PlayerData>().slot2)
                        ddMAn.ShowBox("You already have this potion.");
                    else Check(price, slot);
                    break;
                case 3:
                    if (playerStats.GetComponent<PlayerData>().slot3)
                        ddMAn.ShowBox("You already have this potion.");
                    else Check(price, slot);
                    break;
                case 4:
                    if (playerStats.GetComponent<PlayerData>().slot4)
                        ddMAn.ShowBox("You already have this potion.");
                    else Check(price, slot);
                    break;
                case 5:
                    if (playerStats.GetComponent<PlayerData>().slot5)
                        ddMAn.ShowBox("You already have this potion.");
                    else Check(price, slot);
                    break;
                case 6:
                    if (playerStats.GetComponent<PlayerData>().slot6)
                        ddMAn.ShowBox("You already have this potion.");
                    else Check(price, slot);
                    break;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerinzone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerinzone = false;
            ddMAn.DisableBox();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ddMAn.ShowBox(dialogue);
        }

    }

    void Check(int price, int slot)
    {
        if (playerStats.GetComponent<PlayerData>().coins < price)
            ddMAn.ShowBox("Not enough gold");
        else
        {
            playerStats.GetComponent<PlayerData>().PotionBought(slot, price);
            ddMAn.ShowBox("Gratz! You bought the potion. Put 'em to good use in battle.");
        }
    }

}

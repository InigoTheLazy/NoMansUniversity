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
    private bool justBought = false;

    void Start()
    {
        playerStats = GameObject.Find("PlayerGM(Clone)");
        playerinzone = false;
        ddMAn = FindObjectOfType<DialogueManager>();
    }
    void Update()
    {
        if (playerinzone && Input.GetKey(KeyCode.E))
        {
            switch (slot)
            {
                case 1:
                    if (playerStats.GetComponent<PlayerData>().slot1)
                        dialogue = "You already have this potion.";
                    else Check(price, slot);
                    break;
                case 2:
                    if (playerStats.GetComponent<PlayerData>().slot2)
                        dialogue = "You already have this potion.";
                    else Check(price, slot);
                    break;
                case 3:
                    if (playerStats.GetComponent<PlayerData>().slot3)
                        dialogue = "You already have this potion.";
                    else Check(price, slot);
                    break;
                case 4:
                    if (playerStats.GetComponent<PlayerData>().slot4)
                        dialogue = "You already have this potion.";
                    else Check(price, slot);
                    break;
                case 5:
                    if (playerStats.GetComponent<PlayerData>().slot5)
                        dialogue = "You already have this potion.";
                    else Check(price, slot);
                    break;
                case 6:
                    if (playerStats.GetComponent<PlayerData>().slot6)
                        dialogue = "You already have this potion.";
                    else Check(price, slot);
                    break;
            }
        }
        else HaveCheck();
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
            dialogue = "Not enough gold";
        else
        {
            playerStats.GetComponent<PlayerData>().PotionBought(slot, price);
            dialogue = "Gratz! You bought the potion. Put 'em to good use in battle.";
            ddMAn.ShowBox(dialogue);
            justBought = true;
        }
    }

    void HaveCheck()
    {
        if (justBought)
            dialogue = "Gratz! You bought the potion. Put 'em to good use in battle.";
        else
        {
            switch (slot)
            {
                case 1:
                    if (playerStats.GetComponent<PlayerData>().slot1)
                        dialogue = "You already have this potion.";
                    break;
                case 2:
                    if (playerStats.GetComponent<PlayerData>().slot2)
                        dialogue = "You already have this potion.";
                    break;
                case 3:
                    if (playerStats.GetComponent<PlayerData>().slot3)
                        dialogue = "You already have this potion.";
                    break;
                case 4:
                    if (playerStats.GetComponent<PlayerData>().slot4)
                        dialogue = "You already have this potion.";
                    break;
                case 5:
                    if (playerStats.GetComponent<PlayerData>().slot5)
                        dialogue = "You already have this potion.";
                    break;
                case 6:
                    if (playerStats.GetComponent<PlayerData>().slot6)
                        dialogue = "You already have this potion.";
                    break;
            }
        }
    }

}

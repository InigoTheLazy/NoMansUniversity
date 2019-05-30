using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopBuyer : MonoBehaviour
{
    public string dialogue;
    private DialogueManager ddMAn;
    private bool playerinzone;
    void Start()
    {
        playerinzone = false;
        ddMAn = FindObjectOfType<DialogueManager>();
    }
    void Update()
    {
        if (playerinzone && Input.GetKeyDown(KeyCode.E))
        {
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEnter : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMAn;
    private bool playerinzone;
    [SerializeField] private string loadlevel;

    void Start()
    {
        playerinzone = false;
        dMAn = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if ( playerinzone && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(loadlevel);
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
            if (dMAn != null)
                dMAn.DisableBox();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            dMAn.ShowBox(dialogue);
        }

    }
}

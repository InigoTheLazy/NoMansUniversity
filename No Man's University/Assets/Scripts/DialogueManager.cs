using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    
    void Update()
    {
        if (dialogActive && Input.GetKeyUp(KeyCode.E))
        {
            dBox.SetActive(false);
            dialogActive = false;
        }
    }
    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
    public void DisableBox()
    {
        dialogActive = false;
        dBox.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class InformationText : MonoBehaviour
{
    public string attackTextBox;
    public string skillTextBox;
    public string itemTextBox;
    public string runTextBox;

    public GameObject informationBox;

    void Start()
    {
        AssignTextBox();
    }

    public void ChangeTextBox(string textBoxName)
    {
        informationBox.gameObject.GetComponent<Text>().text = textBoxName;
    }

    private void AssignTextBox()
    {
        attackTextBox = "Basic attack. Deal moderate damage.";
        skillTextBox = "Special attack. Can be used every other turn. Deals high damage.";
        itemTextBox = "Potion inventory. A potion can be used once per battle.";
        runTextBox = "Giving up now? Didn't expect any less.";
    }

   
}

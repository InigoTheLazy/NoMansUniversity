using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        
    }

    public void ChangeTextBox(string textBoxName)
    {
        informationBox.gameObject.GetComponent<Text>().text = textBoxName;
    }

    private void AssignTextBox()
    {
        attackTextBox = "Deal 40 damage. Zoinks.";
        skillTextBox = "Does a flying kick dishing out tons of damage.";
        itemTextBox = "For now its run";
        runTextBox = "Giving up now? Didn't expect any less.";
    }

   
}

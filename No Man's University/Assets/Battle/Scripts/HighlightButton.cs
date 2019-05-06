using UnityEngine;
using UnityEngine.UI;

public class HighlightButton : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public GameObject selectCursor;

    public GameObject BattleGameMaster;

    private Transform cursorPosition;

    private Vector3 cursorPos1 = new Vector3(-3.5f, -1.63f);
    private Vector3 cursorPos2 = new Vector3(-3.5f, -2.46f);
    private Vector3 cursorPos3 = new Vector3(-3.5f, -3.29f);
    private Vector3 cursorPos4 = new Vector3(-3.5f, -4.12f);

    void Start()
    {
        cursorPosition = selectCursor.transform;
    }

    void Update()
    {
        if (cursorPosition.position.y == cursorPos1.y)
        {
            SelectButton(button1, BattleGameMaster.GetComponent<InformationText>().attackTextBox);
        }
        else if (cursorPosition.position.y == cursorPos2.y)
        {
            SelectButton(button2, BattleGameMaster.GetComponent<InformationText>().skillTextBox);
        }
        else if (cursorPosition.position.y == cursorPos3.y)
        {
            SelectButton(button3, BattleGameMaster.GetComponent<InformationText>().itemTextBox);
        }
        else if (cursorPosition.position.y == cursorPos4.y)
        {
            SelectButton(button4, BattleGameMaster.GetComponent<InformationText>().runTextBox);
        }
        else
        {
            SelectButton(button1, BattleGameMaster.GetComponent<InformationText>().attackTextBox);
        }
    }

    private void SelectButton(GameObject button, string textBox)
    {
        button.gameObject.GetComponent<Button>().Select();
        BattleGameMaster.GetComponent<InformationText>().ChangeTextBox(textBox);
    }
    
}

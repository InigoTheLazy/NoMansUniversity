using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public GameObject selectCursor;
    private Vector3 cursorStart;
    private Vector3 cursorEnd;

    void Start()
    {
        cursorStart = new Vector3(-3.5f, -1.63f);
        cursorEnd = new Vector3(-3.5f, -4.12f);
        ChangeCursorVector(cursorStart);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && selectCursor.transform.position.y < -1.64f)
        {
            AlterCursorVector(0.83f);
        }

        else if (Input.GetKeyDown(KeyCode.W) && (selectCursor.transform.position == cursorStart))
        {
            ChangeCursorVector(cursorEnd);
        }

        else if (Input.GetKeyDown(KeyCode.S) && selectCursor.transform.position.y > -4.12f)
        {
            AlterCursorVector(-0.83f);
        }

        else if (Input.GetKeyDown(KeyCode.S) && (selectCursor.transform.position == cursorEnd))
        {
            ChangeCursorVector(cursorStart);
        }
    }

    private void AlterCursorVector(float change)
    {
        Vector3 cursorMovement = new Vector2(0f, change);
        selectCursor.transform.position = selectCursor.transform.position + cursorMovement;
    }
    private void ChangeCursorVector(Vector3 cursorPositionVector)
    {
        selectCursor.transform.position = cursorPositionVector;
    }

}

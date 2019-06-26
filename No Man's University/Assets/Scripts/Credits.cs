using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private string loadLevel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (loadLevel != "")
                SceneManager.LoadScene(loadLevel);
    }
}

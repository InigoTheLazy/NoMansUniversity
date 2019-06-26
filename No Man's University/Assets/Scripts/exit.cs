using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    [SerializeField] private string loadlevel;
    public GameObject walkingPlayer;
    // Start is called before the first frame update
    void Start()
    {
        walkingPlayer = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            walkingPlayer.SetActive(true);
            SceneManager.LoadScene(loadlevel);


        }
    }
}

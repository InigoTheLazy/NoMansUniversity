using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    public string pointName;
    private Player thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
        if(thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

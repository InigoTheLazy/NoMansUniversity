using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    public string pointName;
    private Player thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();

        if (thePlayer.startPoint == pointName)
            thePlayer.transform.position = transform.position;
    }
}

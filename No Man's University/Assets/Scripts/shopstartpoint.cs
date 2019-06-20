using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopstartpoint : MonoBehaviour
{
    public string pointName;
    private Player thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
            thePlayer.transform.position = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int PMoney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMoney(int amount)
    {
        PMoney += amount;
    }
    public void SubtractMoney(int amount)
    {
        if (PMoney - amount < 0)
        {
            Debug.Log("Not enough money");
        }
        else
        {
            PMoney -= amount;
        }
    }
}

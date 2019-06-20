using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int PMoney;

    public void AddMoney(int amount)
    {
        PMoney += amount;
    }

    public void SubtractMoney(int amount)
    {
        if (PMoney - amount < 0)
            Debug.Log("Not enough money");
        else
            PMoney -= amount;
    }
}

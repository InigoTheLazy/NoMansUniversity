using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (battleflow.whichturn == 2)
        {
            GetComponent<Animator>().SetTrigger("enemyAttack");
            battleflow.whichturn = 1;
        }
    }

   
}

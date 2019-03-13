using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herocon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && battleflow.whichturn == 1)
        {
            GetComponent<Animator>().SetTrigger("heroAttack");
            StartCoroutine(turnEnd());
        }
    }

    IEnumerator turnEnd()
    {
        yield return new WaitForSeconds(4);
        battleflow.whichturn = 2;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemycon : MonoBehaviour
{
    public float enemyHP = 100;
    public float enemyMaxHP = 100;
    public float enemyAttPow = 50;
    public Transform damTextObj;
    public Slider healthBar;
    public Text HPText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = enemyMaxHP;
        healthBar.value = enemyHP;
        HPText.text = enemyHP + "/" + enemyMaxHP;

        if (battleflow.whichturn == 2)
        {
            GetComponent<Animator>().SetTrigger("enemyAttack");
            StartCoroutine(turnEnd());
            Invoke("EnemyTurnEnd", 3);
        }

        if (battleflow.damageDisplay == "y" && battleflow.whichturn != 2)
        {
            enemyHP -= battleflow.currentDamage;
            battleflow.damageDisplay = "n";
        }

        if (enemyHP<=0)
        {
            battleflow.enemyDefeated = "y";
            Destroy(gameObject);
        }

        
    }

    IEnumerator turnEnd()
    {
        battleflow.whichturn = 0;
        yield return new WaitForSeconds(4);
        battleflow.currentDamage = 50;
        herocon.heroHP -= battleflow.currentDamage;
        Instantiate(damTextObj, new Vector2(-6f, 4.95f), damTextObj.rotation);
    }

    private void EnemyTurnEnd()
    {
        battleflow.whichturn = 1;
    }

}


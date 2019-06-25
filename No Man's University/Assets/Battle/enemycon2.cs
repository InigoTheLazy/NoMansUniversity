using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class enemycon2 : MonoBehaviour
{
    public float enemyHP = 300;
    public float enemyMaxHP = 300;
    public float enemyAttPow = 100;
    public Transform damTextObj;
    public Slider healthBar;
    public Text HPText;

    void Update()
    {
        healthBar.maxValue = enemyMaxHP;
        healthBar.value = enemyHP;
        HPText.text = enemyHP + "/" + enemyMaxHP;

        if (battleflow.whichturn == 2)
        {
            float a = 1;
            int randomNumber = Random.Range(0, 2);
            switch (randomNumber)
            {
                case 0:
                    GetComponent<Animator>().SetTrigger("enemyAttack");
                    break;
                case 1:
                    GetComponent<Animator>().SetTrigger("enemyAttack2");
                    a= 1.5f;
                    break;
            }
            StartCoroutine(turnEnd(a));
            Invoke("EnemyTurnEnd", 3);
        }

        if (battleflow.damageDisplay == "y" && battleflow.whichturn != 2)
        {
            enemyHP -= battleflow.currentDamage;
            battleflow.damageDisplay = "n";
        }

        if (enemyHP <= 0)
        {
            battleflow.enemyDefeated = "y";
            battleflow.enemyNumber = 1;
            Destroy(gameObject);
        }


    }

    IEnumerator turnEnd(float a)
    {
        battleflow.whichturn = 0;
        yield return new WaitForSeconds(4);
        float b = (1 - (battleflow.armor / 200));
        battleflow.currentDamage = Mathf.Ceil(enemyAttPow * battleflow.damageMultiplier * a * b);
        herocon.heroHP -= battleflow.currentDamage;
        Instantiate(damTextObj, new Vector2(-6f, 4.95f), damTextObj.rotation);
    }

    private void EnemyTurnEnd()
    {
        battleflow.whichturn = 1;
    }

}


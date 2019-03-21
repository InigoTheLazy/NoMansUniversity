using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class herocon : MonoBehaviour
{
    public static float heroHP = 100;
    public static float heroMaxHP = 100;
    public Transform damTextObj;
    public Slider healthBar;
    public Text HPText;
    public Button button1;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = heroMaxHP;
        healthBar.value = heroHP;
        HPText.text = "HP: " + heroHP + "/" + heroMaxHP;

        if (heroHP <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenuScene");
            heroHP = 100;
        }

    }

    IEnumerator turnEnd()
    {
        yield return new WaitForSeconds(4);
        battleflow.whichturn = 2;
        Instantiate(damTextObj, new Vector2(5.85f, 4.95f), damTextObj.rotation);
        battleflow.damageDisplay = "y";
    }

    public void attack1 ()
    {
        battleflow.currentDamage = 40;
        GetComponent<Animator>().SetTrigger("heroAttack");
        StartCoroutine(turnEnd());
    }

    public void skill1 ()
    {
        battleflow.currentDamage = 99;
        GetComponent<Animator>().SetTrigger("heroSkill");
        StartCoroutine(turnEnd());
    }
}


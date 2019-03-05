using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text health;
    public Text encumbrance;
    public Text gameOver;
    public Text gameOver_shadow;
    public Slider healthBar;
    public Slider encumbranceBar;
    public Text upgradeButtons;
    public Text leaveShop;
    public Text upgradeButtons_shadow;
    public Text leaveShop_shadow;
    public Text score;
    public Text scoreShadow;
    public int scoreNum;

    private int timer = 0;
    // Start is called before the first frame update
    PlayerRun playerR = null;
    void Start()
    {
        playerR = GetComponent<PlayerRun>();
        SetHealthText();
        SetEncumbranceText();
        upgradeButtons.enabled = false;
        leaveShop.enabled = false;
        upgradeButtons_shadow.enabled = false;
        leaveShop_shadow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        SetHealthText();
        SetEncumbranceText();
        GameOver();
        if (timer % 1000 == 0)
        {
            print("eat my oreos");
        }

        if (PlayerRun.isInShop == true)
        {

            upgradeButtons.enabled = true;
            leaveShop.enabled = true;
            upgradeButtons_shadow.enabled = true;
            leaveShop_shadow.enabled = true;

        }
        if (PlayerRun.isInShop == false || PlayerRun.outOfGold || DeleteItem.currentHealth <= 0)
        {
            if (!PlayerRun.outOfGold && DeleteItem.currentHealth > 0)
            {
                Score();
            }      
            upgradeButtons.enabled = false;
            leaveShop.enabled = false;
            upgradeButtons_shadow.enabled = false;
            leaveShop_shadow.enabled = false;

        }


    }

    void SetHealthText()
    {
        health.text = "Health";
        //healthBar.value = playerR.currentHealth;
        healthBar.value = DeleteItem.currentHealth;

    }

    void SetEncumbranceText()
    {
        encumbrance.text = "Encumbrance";
        encumbranceBar.value = playerR.encumbrance;
    }

    void GameOver()
    {
        if(DeleteItem.currentHealth <= 0 || PlayerRun.outOfGold)
        {
            if (DeleteItem.currentHealth <= 0 && !PlayerRun.outOfGold)
            {
                gameOver.text = "Game Over\nYou Are Dead";
                gameOver_shadow.text = "Game Over\nYou Are Dead";
            }
            else if (PlayerRun.outOfGold && DeleteItem.currentHealth > 0)
            {
                gameOver.text = "Game Over\nOut of Gold!";
                gameOver_shadow.text = "Game Over\nOut of Gold!";
            }
        }
        else
        {
            gameOver.text = "";
            gameOver_shadow.text = "";
        }
    }

    void Score()
    {
       // if (!PlayerRun.isInShop)
       // {
            scoreNum++;
            score.text = "Score: " + scoreNum;
            scoreShadow.text = "Score: " + scoreNum;

        //}
    }




    /*bool Timer(int max, int min, int start)
   {
       bool t;
       if (start >= max)
       {
           t = true;
           start = min;
       }
       else
       {
           t = false;
           start++;
       }
       print(start);
       return t;

   }*/
}

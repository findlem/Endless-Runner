using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text health;
    public Text encumbrance;
    public Text gameOver;
    public Slider healthBar;
    public Slider encumbranceBar;
    public Text upgradeButtons;
    public Text leaveShop;
    
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

        }
        if(PlayerRun.isInShop == false)
        {

            upgradeButtons.enabled = false;
            leaveShop.enabled = false;

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
            gameOver.text = "Game Over";
        }
        else
        {
            gameOver.text = "";
        }
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

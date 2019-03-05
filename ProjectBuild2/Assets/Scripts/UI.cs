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
    public Text leaveShop_shadow;
    public Text score;
    public Text scoreShadow;
    public Text pADesc;
    public Text wWDesc;
    public Text hRDesc;
    public Text iSDesc;
    public Text sBDesc;
    public Text tBDesc;
    public Image pickaxeUp;
    public Image pickaxeUpShop;
    public Image ironSkin;
    public Image ironSkinShop;
    public Image wineWind;
    public Image wineWindShop;
    public Image highRollers;
    public Image highRollersShop;
    public Image tailoredBoots;
    public Image tailoredBootsShop;
    public Image soapBandagesShop;
    public int scoreNum;

    private int timer = 0;
    // Start is called before the first frame update
    PlayerRun playerR = null;
    void Start()
    {
        playerR = GetComponent<PlayerRun>();
        SetHealthText();
        SetEncumbranceText();
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
            pADesc.enabled = true;
            wWDesc.enabled = true;
            hRDesc.enabled = true;
            iSDesc.enabled = true;
            sBDesc.enabled = true;
            tBDesc.enabled = true;
            pickaxeUpShop.enabled = true;
            ironSkinShop.enabled = true;
            wineWindShop.enabled = true;
            highRollersShop.enabled = true;
            tailoredBootsShop.enabled = true;
            soapBandagesShop.enabled = true;
            leaveShop.enabled = true;
            leaveShop_shadow.enabled = true;

        }
        if (PlayerRun.isInShop == false || PlayerRun.outOfGold || DeleteItem.currentHealth <= 0)
        {
            if (!PlayerRun.outOfGold && DeleteItem.currentHealth > 0)
            {
                Score();
            }
            pADesc.enabled = false;
            wWDesc.enabled = false;
            hRDesc.enabled = false;
            iSDesc.enabled = false;
            sBDesc.enabled = false;
            tBDesc.enabled = false;
            pickaxeUpShop.enabled = false;
            ironSkinShop.enabled = false;
            wineWindShop.enabled = false;
            highRollersShop.enabled = false;
            tailoredBootsShop.enabled = false;
            soapBandagesShop.enabled = false;
            
            leaveShop.enabled = false;
            leaveShop_shadow.enabled = false;

        }

        UpgradeImages();
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

    void UpgradeImages()
    {
        if (PlayerRun.Active)
        {
            pickaxeUp.enabled = true;
        } 
        if (!PlayerRun.Active)
        {
            pickaxeUp.enabled = false;
        }

        if (PlayerRun.PupActive)
        {
            ironSkin.enabled = true;
        }
        if (!PlayerRun.PupActive)
        {
            ironSkin.enabled = false;
        }

        if (PlayerRun.PupActive2)
        {
            wineWind.enabled = true;
        }
        if (!PlayerRun.PupActive2)
        {
            wineWind.enabled = false;
        }

        if (PlayerRun.highRollersRumActive)
        {
            highRollers.enabled = true;
        }
        if (!PlayerRun.highRollersRumActive)
        {
            highRollers.enabled = false;
        }

        /*if (PlayerRun.tailoredBoots)
        {
            tailoredBoots.enabled = true;
        }
        if (!PlayerRun.tailoredBoots)
        {
            tailoredBoots.enabled = false;
        }*/
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

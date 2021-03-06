﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text health;
    public Text encumbrance;
    public Slider healthBar;
    public Slider encumbranceBar;
    public Button pauseButton;
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
        if (timer % 1000 == 0)
        {
            print("eat my oreos");
        }
    }

    void SetHealthText()
    {
        health.text = "Health";
        healthBar.value = playerR.currentHealth;

    }

    void SetEncumbranceText()
    {
        encumbrance.text = "Encumbrance";
        encumbranceBar.value = playerR.encumbrance;
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

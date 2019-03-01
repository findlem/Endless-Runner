using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe_attack : MonoBehaviour
{

    public GameObject pick_axe;
    public GameObject visual_axe;
    public GameObject pivot_rotate;
    private int swing_time = 0;
    private int swing_back = 0;
    private int cool_down = 50;
    private int add = 0;
    private int add2 = 0;
    private float rotation_speed = 6;
    private bool wasSwung = false;
    private bool triggerCoolDown = false;

    public bool Active = false; // used to check for upgrades in other scripts
    public bool PowerUp1 = false;

    void Start()
    {
        PowerUp1 = true;

    }

    // Update is called once per frame
    void Update()
    {

        bool click_active = Input.GetButtonDown("Jump");
        if (triggerCoolDown == false)
        {
            if (click_active == true)
            {
                add = 1;
                wasSwung = true;
                triggerCoolDown = true;
                PlayerRun.sourcePickaxeSwing.Play();
                add2 = 1;
            }
        }

        if(swing_time >= 15)
        {
            add = 0;
            swing_time = 0;
        }
        
        if(swing_time <= 0)
        {
            pick_axe.SetActive(false);
            visual_axe.SetActive(false);

        }
        if(swing_time > 0)
        {
            pick_axe.SetActive(true);
            visual_axe.SetActive(true);
        }
        if (add == 1 && wasSwung == true)
        {
            pivot_rotate.transform.Rotate(rotation_speed, 0f, 0f); // rotates the pickaxe
            
        }
        if(add == 0 && wasSwung == true)
        {
            swing_back += 1;
        }
        if(swing_back >= 1)
        {
            pivot_rotate.transform.Rotate(-90f, 0f, 0f); // the x # depends on the rotation_speed and swing_time. It resets the x rotation value that was made all at once
            wasSwung = false;
            swing_back = 0;

        }
        
        if(cool_down <= 0)
        {
            triggerCoolDown = false;
            add2 = 0;
            cool_down = 50;
        }


        swing_time += add;
        cool_down -= add2;

        


    }
}

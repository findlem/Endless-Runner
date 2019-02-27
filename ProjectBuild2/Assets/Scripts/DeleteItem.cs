using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    private int objectType = 1; //1 = wall; 2 = ...
    ColliderAABB refAABB;

    //these variables will be used for health, and are used in calculating speed
    static public float maxHealth = 3; //subject to change, especially with powerups
    static public float currentHealth = 3; //also subject to change, obviously
    static public float mercyInvincibility = 0; //used to make sure the player doesn't get bodied by a bunch of stuff at once

    // Start is called before the first frame update
    void Start()
    {
        refAABB = GetComponent<ColliderAABB>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mercyInvincibility >= 0) //constantly ticked down mercyInvincibility, or otherwise sets to 0
        {
            mercyInvincibility -= (0.20f * Time.deltaTime);
            //print(mercyInvincibility);
        }
        if (mercyInvincibility < 0)
        {
            mercyInvincibility = 0;
        }

        if (refAABB.isDead)
        {
            if(objectType == 1 && SceneController.PickAxeHit == false && SceneController.powerup1 == false)
            {
                if (currentHealth >= 1f && mercyInvincibility <= 0)
                {
                    currentHealth -= 1f;
                    mercyInvincibility = 5f;

                    if (currentHealth != 0f)
                    {
                        PlayerRun.sourceWoo.Play();
                        print("smol woo");
                    }
                    if (currentHealth <= 0f)
                    {
                        PlayerRun.sourceLongWoo.Play();
                        print("BIG WOO");
                    }
                }
                print("Collision! Max Health = " + maxHealth + "; Current Health = " + currentHealth);

                SceneController.walls.Remove(gameObject);
                Destroy(gameObject);
                PlayerRun.sourceBreakRock.Play();
            }
            if(objectType == 1 && SceneController.PickAxeHit == true)
            {
                SceneController.walls.Remove(gameObject);
                Destroy(gameObject);
                PlayerRun.sourceBreakRock.Play();
                SceneController.PickAxeHit = false;
            }
            if (objectType == 1 && SceneController.powerup1 == true)
            {
                SceneController.walls.Remove(gameObject);
                Destroy(gameObject);
                PlayerRun.sourceBreakRock.Play();
            }

        }
    }
}

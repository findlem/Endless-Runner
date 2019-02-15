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

    // Start is called before the first frame update
    void Start()
    {
        refAABB = GetComponent<ColliderAABB>();
    }

    // Update is called once per frame
    void Update()
    {
        if (refAABB.isDead)
        {
            if(objectType == 1)
            {
                currentHealth -= 1f; //** TEMPORARY **; might need to be moved elsewhere
                print("Collision! Max Health = " + maxHealth + "; Current Health = " + currentHealth);

                SceneController.walls.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}

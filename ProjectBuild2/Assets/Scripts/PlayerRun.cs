using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public float speed = 10; //default, non-slowed speed
    public float encumbrance = 0;
    //public float maxHealth = 3; //** TEMPORARY **; does not link with AABB collision yet
    //public float currentHealth = 3; //** TEMPORARY **; does not link with AABB collision yet
    //public float move_speed = 8;

    //bool switch1 = false;

    //start Nathan's sliding variables
    private float currentLane = 2; //1 = left, 2 = center, 3 = right
    private float previousLane = 0;
    private float movingInDirection = 0; //1 = left, 2 = right
    private bool isChangingLanes = false; //if true, lock arrow keys until false
    private float prevXPos = 0; //pos.x is being finnicky; hopefully this fixes that
    //end Nathan's sliding variables

    //public float pause = 0;
    //private bool isPaused = false;

    Rigidbody rb;
    DeleteItem di;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        di = GetComponent<DeleteItem>();
    }

    // Update is called once per frame
    void Update()
    {
       /* bool pKey = Input.GetButtonDown("Pause");
        if (pKey)
        {
            isPaused = !isPaused;
        }*/

       // if (!isPaused)
        //{
            
            //transform.Translate(x * Time.deltaTime * move_speed, 0, 0);
            //moving forwards
            speed = 10; //reset speed first
            encumbrance += 0.025f; //** TEMPORARY **; gradually ticks up encumbrance over time for testing purposes
            if (encumbrance >= 10)
            {
                encumbrance = 10;
            }
            //currentHealth = 1; //** TEMPORARY **; used to help check the minimum speed the player can reach
            speed = speed - ((encumbrance / 3) + (((DeleteItem.currentHealth / DeleteItem.maxHealth) - 1) * -3)); //** NOTE **: the health side of this might need tweaking
            Vector3 pos = transform.position;
            //print("Speed = " + speed + "; Encumbrance = " + encumbrance + "; Current Health = " + DeleteItem.currentHealth); //prints all relevant variables
            pos.z += speed * Time.deltaTime;

            //moving left and right
            bool left = Input.GetKeyDown("left");
            bool right = Input.GetKeyDown("right");
            //Nathan's movement code
            //instances where player cannot move
            /*if (left == true && currentLane == 1 && isChangingLanes == false)
            {
                print("Can't move left!");
            }
            if (right == true && currentLane == 3 && isChangingLanes == false)
            {
                print("Can't move right!");
            }
            if (isChangingLanes == true && right == true || left == true)
            {
                print("Already moving!");
            }*/
            //if player can move
            if (left == true && currentLane == 3 && isChangingLanes == false)
            {
                movingInDirection = 1; //left
                previousLane = currentLane;
                currentLane = 2; //right to middle
                isChangingLanes = true;
                prevXPos = 1; //player's x position
            }
            if (left == true && currentLane == 2 && isChangingLanes == false)
            {
                movingInDirection = 1; //left
                previousLane = currentLane;
                currentLane = 1; //middle to left
                isChangingLanes = true;
                prevXPos = 0; //player's x position
            }
            if (right == true && currentLane == 1 && isChangingLanes == false)
            {
                movingInDirection = 2; //right
                previousLane = currentLane;
                currentLane = 2; //left to middle
                isChangingLanes = true;
                prevXPos = -1; //player's x position
            }
            if (right == true && currentLane == 2 && isChangingLanes == false)
            {
                movingInDirection = 2; //right
                previousLane = currentLane;
                currentLane = 3; //left to middle
                isChangingLanes = true;
                prevXPos = 0; //player's x position
            }

            //and now, sliding the player
            if (isChangingLanes == true)
            {
                if (movingInDirection == 1) //moving left
                {
                    if (previousLane == 3 && prevXPos > 0)
                    {
                        prevXPos -= 0.1f;
                    }
                    if (previousLane == 3 && prevXPos <= 0)
                    {
                        isChangingLanes = false;
                        prevXPos = 0; //makes doubly sure you stop at: middle
                        movingInDirection = 0;
                    }
                    if (previousLane == 2)
                    {
                        prevXPos -= 0.1f;
                    }
                    if (previousLane == 2 && prevXPos <= -1)
                    {
                        isChangingLanes = false;
                        prevXPos = -1; //makes doubly sure you stop at: left
                        movingInDirection = 0;
                    }
                }

                if (movingInDirection == 2) //moving right
                {
                    if (previousLane == 1 && prevXPos < 0)
                    {
                        prevXPos += 0.1f;
                    }
                    if (previousLane == 1 && prevXPos >= 0)
                    {
                        isChangingLanes = false;
                        prevXPos = 0;
                        movingInDirection = 0;
                    }
                    if (previousLane == 2 && prevXPos < 1)
                    {
                        prevXPos += 0.1f;
                    }
                    if (previousLane == 2 && prevXPos >= 1)
                    {
                        isChangingLanes = false;
                        prevXPos = 1;
                        movingInDirection = 0;
                    }
                }
            }
            pos.x = prevXPos;
            transform.position = pos;
        //}

        /*else if(isPaused)
        {
            speed = 0.5f;
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
 
        if(other.gameObject.tag == "rock")
        {
            Destroy(other.gameObject);

            DeleteItem.currentHealth -= 1f;
            print("Speed = " + speed + "; Encumbrance = " + encumbrance + "; Current Health = " + DeleteItem.currentHealth);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gold")
        {
            Destroy(other.gameObject);
            print("GET MONEY!!");
        }
    }
}

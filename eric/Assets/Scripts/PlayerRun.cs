using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{

    public float speed = 10;
    public float move_speed = 8;
    public float jumpForce = 2;
    public Vector3 jump;
    private bool isGrounded = true;


    //start Nathan's sliding variables
    private float currentLane = 2; //1 = left, 2 = center, 3 = right
    private float previousLane = 0;
    private float movingInDirection = 0; //1 = left, 2 = right
    private bool isChangingLanes = false; //if true, lock arrow keys until false
    private float prevXPos = 0; //pos.x is being finnicky; hopefully this fixes that
                                //end Nathan's sliding variables


    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //transform.Translate(x * Time.deltaTime * move_speed, 0, 0);

        if (isGrounded)
        {
            if(Input.GetKeyDown("up"))
            {
                rb.velocity = Vector3.up * jumpForce;
                //isGrounded = false;
                
            }
           
        }



        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;
        bool left = Input.GetKeyDown("left");
        bool right = Input.GetKeyDown("right");

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

        if (pos.y > 0.5)
        {
            isGrounded = false;
        }
        if (pos.y <= 0.5)
        {
            isGrounded = true;
        }

        transform.position = pos;



    }

    private void OnTriggerEnter(Collider other) // AABB didnt work so I used this
    {
        if(other.gameObject.tag == "wall")
        {
            print("och!");
        }

        if (other.gameObject.tag == "rock")
        {
            print("och!");
        }

    }

}

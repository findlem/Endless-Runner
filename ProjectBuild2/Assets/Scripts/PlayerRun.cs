using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public AudioClip clipWoo;
    public AudioClip clipLongWoo;
    public AudioClip clipGoldPickUp;
    public AudioClip clipBreakRock;
    public AudioClip clipFootstep;
    public AudioClip clipPickaxeSwing;
    public AudioClip trackGameBGM;
    public AudioClip trackGameOver;
    //define the audio sources; need to be static for now so other scripts can reference them
    public static AudioSource sourceWoo;
    public static AudioSource sourceLongWoo;
    public static AudioSource sourceGoldPickUp;
    public static AudioSource sourceBreakRock;
    public static AudioSource sourceFootstep;
    public static AudioSource sourcePickaxeSwing;
    public static AudioSource sourceGameBGM;
    public static AudioSource sourceGameOver;

    public float speed = 10; //default, non-slowed speed
    public float encumbrance = 0; //will default to 5 now; bag starts half full
    public static bool outOfGold = false; //if this is ever ticked true, the dwarf will stop running and get burned
    public static bool isInShop = false;
    public static bool Active = false; // used to check for upgrades in other scripts
    public bool pickaxeBought = false;
    public static bool PowerUp1 = false;
    public static bool PupActive = false;
    public static bool PowerUp2 = false;
    public static bool PupActive2 = false;
    public static bool tailoredBoots = false;
    private int PUp2Timer = 0;

    public static float score = 0f; //player earns points over time
    private float scoreDelay = 0.5f; //delay between points earned
    public static float shopScore = 0f; //tied to score; used for shop spawning

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

        encumbrance = 5; //defaults to half-full on game start
        PowerUp1 = true;

        sourceGameBGM.Play();
        sourceFootstep.Play(); //** TEMPORARY **; will need to move this somewhere else if/when we make a title screen
        PupActive = true;
    }

    public AudioSource AddAudio (AudioClip clip, bool loop, bool playAwake, float vol)
    {
        //assigns the appropriate AudioClip and properties to each new AudioSource
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;
    }

    void Awake()
    {
        //adds the necessary AudioSources
        sourceWoo = AddAudio(clipWoo, false, false, 0.9f);
        sourceLongWoo = AddAudio(clipLongWoo, false, false, 0.9f);
        sourceGoldPickUp = AddAudio(clipGoldPickUp, false, false, 0.9f);
        sourceBreakRock = AddAudio(clipBreakRock, false, false, 0.9f);
        sourceFootstep = AddAudio(clipFootstep, true, false, 0.9f);
        sourceGameBGM = AddAudio(trackGameBGM, true, false, 1.0f);
        sourceGameOver = AddAudio(trackGameOver, false, false, 0.5f);
        sourcePickaxeSwing = AddAudio(clipPickaxeSwing, false, false, 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        //calculate score; also used to determine LavaFlow.cs speed
        if(outOfGold == false && DeleteItem.currentHealth > 0 && isInShop == false)
        {
            scoreDelay -= 1f * Time.deltaTime;
            if (scoreDelay <= 0f)
            {
                scoreDelay = 0.5f;
                score += 1f;
                shopScore += 1f;
                //print(score);
                //print(shopScore);
            }
        }

        //moving forwards

        //NOTE: This gradually drains away your encumbrance; as in, you slowly lose gold!
        //had trouble letting other scripts change encumbrance, so now the rate of loss goes up as your health goes down

        if (!isInShop)
        {
            speed = 10; //reset speed first
            encumbrance -= ((1 * Time.deltaTime) / (DeleteItem.currentHealth + 1)); //adds 1 so it doesn't try to divide by 0
            if (Input.GetKeyDown("o") && PupActive == true) // Example used for powerups for future reference
            {
                PowerUp1 = true;
            }
            if (Input.GetKeyDown("u") && PupActive2 == true)
            {
                PowerUp2 = true;
            }

        } else
        {
            speed = 0 + ((encumbrance / 3) + (((DeleteItem.currentHealth / DeleteItem.maxHealth) - 1) * -3)); ;
            if (Input.GetKeyDown("escape"))
            {
                isInShop = false;
            }
            //encumbrance = 5;
            if (Input.GetKeyDown("p") && encumbrance >= 6 && pickaxeBought == false) // Example used for upgrades for future reference
            {
                Active = true;
                encumbrance = encumbrance - 6;
                pickaxeBought = true;
            }
            
            if (Input.GetKeyDown("o") && encumbrance >= 4 && PupActive == false) // Example used for powerups for future reference
            {
               
               encumbrance = encumbrance - 4;
                PupActive = true;
               
            }

            if (Input.GetKeyDown("u") && encumbrance >= 4 && PupActive2 == false)
            {
                PupActive2 = true;
                encumbrance = encumbrance - 4;
            }
            if (Input.GetKeyDown("k") && encumbrance >= 2 && DeleteItem.currentHealth < 3)
            {
                DeleteItem.currentHealth = 3;
                encumbrance = encumbrance - 2;
            }
            if (Input.GetKeyDown("l"))
            {
                //something
            }
            if (Input.GetKeyDown("j") && encumbrance >= 4)
            {
                tailoredBoots = true;
                encumbrance = encumbrance - 4;

            }
            
        }

        if(PowerUp2 == true && !isInShop) // This Triggers The Speed Power Up 
        {
            PUp2Timer++;
            speed = speed + 5;
        }
        if(PUp2Timer >= 200)
        {
            PowerUp2 = false;
            PUp2Timer = 0;
            PupActive2 = false;
        }

        
        if (encumbrance >= 10)
        {
            encumbrance = 10;
        }
        if (encumbrance < 0 || DeleteItem.currentHealth == 0) //results in a gameover anyways, but best not keep dropping below 0
        {
            encumbrance = 0; //can throw this into another if statement; dwarf drops his gold when KO'd
            if(outOfGold == false)
            {
                outOfGold = true; //this will be used for our gameOver state; halts all forward movement for the rest of the run
                sourceLongWoo.Play();
                sourceGameOver.Play();
                sourceFootstep.Stop();
                sourceGameBGM.Stop();
            }
        }
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
        if(outOfGold == false)
        {
            transform.position = pos;
        }

        /*else if(isPaused)
        {
            speed = 0.5f;
        }*/

        /*if(isInShop)
        {
            pSpeed = speed;
            speed = 0;
            LavaFlow.speed = 0;
        } else
        {

            LavaFlow.speed = 6;
        }*/
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "rock")
        {
            Destroy(other.gameObject);
            sourceBreakRock.Play();

            if (DeleteItem.currentHealth >= 1 && DeleteItem.mercyInvincibility <= 0)
            {
                DeleteItem.currentHealth -= 1f;
                DeleteItem.mercyInvincibility = 5f;

                if (DeleteItem.currentHealth != 0f)
                {
                    sourceWoo.Play();
                    print("smol woo");
                }
                if (DeleteItem.currentHealth <= 0f)
                {
                    sourceLongWoo.Play();
                    print("BIG WOO");
                }
            }
            //print("Speed = " + speed + "; Encumbrance = " + encumbrance + "; Current Health = " + DeleteItem.currentHealth);
        }

        if(other.gameObject.tag == "lava")
        {
            DeleteItem.currentHealth = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gold")
        {
            Destroy(other.gameObject);
            encumbrance += 1f; //in general, gold piles will give double the gold a boulder will
            sourceGoldPickUp.Play();
        }

        if (other.gameObject.tag == "shop")
        {
            isInShop = true;
        }
    }
}

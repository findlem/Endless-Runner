using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFlow : MonoBehaviour
{


    public float speed = 6;
    PlayerRun playerR = null;
    // Start is called before the first frame update
    void Start()
    {
        playerR = GetComponent<PlayerRun>();

    }

    // Update is called once per frame
    void Update()
    {
        //first, calculate speed
        speed = 6 + (PlayerRun.score / 100); //(also subtract stuff like speed upgrades from this)

        
        if (!PlayerRun.isInShop)
        {
            speed = 6 + (PlayerRun.score / 100);
        } else
        {
            speed = 0 - (PlayerRun.score / 100);
        }
        

        //now, apply speed to transform
        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "rock")
        {
            Destroy(collision.gameObject);
            

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gold")
        {
            Destroy(other.gameObject);
            
        }
    }
}

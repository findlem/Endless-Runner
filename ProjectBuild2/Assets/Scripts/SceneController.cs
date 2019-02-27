using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public GameObject prefabChunk;
    public Transform player;

    List<GameObject> chunks = new List<GameObject>();
    static public List<GameObject> walls = new List<GameObject>();
    static public List<GameObject> rocks = new List<GameObject>();
    static public List<GameObject> golds = new List<GameObject>();
    static public bool PickAxeHit = false;
    static public bool powerup1 = false;
    


    ColliderAABB pBox;

    ColliderAABB pickBox;

    ColliderAABB shieldBox;


    // Start is called before the first frame update
    void Start()
    {

        pBox = GameObject.Find("Player").GetComponent<ColliderAABB>();

        pickBox = GameObject.Find("PickAxe").GetComponent<ColliderAABB>();

        shieldBox = GameObject.Find("shield").GetComponent<ColliderAABB>();



    }

    // Update is called once per frame
    void Update()
    {

        if (chunks.Count > 0)
        {
            if (player.position.z - chunks[0].transform.position.z > 14)
            {
                Destroy(chunks[0]);
                chunks.RemoveAt(0);
            }
        }

        while (chunks.Count < 5)
        {
            // spawn a new chunk
            Vector3 position = Vector3.zero;

            if (chunks.Count > 0)
            {
                position = chunks[chunks.Count - 1].transform.Find("Connector").position;
            }

            GameObject obj = Instantiate(prefabChunk, position, Quaternion.identity);
            chunks.Add(obj);
        }


        if(walls.Count > 0)
        {
            foreach (GameObject wall in walls)
            {
                if (pBox.CheckOverlap(wall.GetComponent<ColliderAABB>()))
                {
                    //print("Collision!");
                    if (wall != null)
                    {
                        //walls.Remove(wall);
                        wall.GetComponent<ColliderAABB>().isDead = true;

                    }
                }
                
                if (pickBox.CheckOverlap(wall.GetComponent<ColliderAABB>()))
                {
                    //print("Collision!");
                    if (wall != null)
                    {
                        //walls.Remove(wall);
                        PickAxeHit = true;
                        wall.GetComponent<ColliderAABB>().isDead = true;

                    }
                }
                if (shieldBox.CheckOverlap(wall.GetComponent<ColliderAABB>()))
                {
                    //print("Collision!");
                    if (wall != null)
                    {
                        //walls.Remove(wall);
                        powerup1 = true;
                        wall.GetComponent<ColliderAABB>().isDead = true;

                    }
                }


            }
        }



    }
}

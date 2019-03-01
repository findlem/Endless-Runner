using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject prefabWall;
    public GameObject prefabGold;
    //KeepCount ss;
   
    public GameObject prefabShop; //had to comment out to temp. fix conflict
    
    // Start is called before the first frame update
    void Start()
    {
        /* //Varun tried this, but it doesn't work
        ss = GetComponent<KeepCount>();
        ss.count += 1f;

        if (ss.count < 6f)
        {
            GameObject s1 = GameObject.Find("Spawn1");
            Destroy(s1);
            GameObject s2 = GameObject.Find("Spawn2");
            Destroy(s2);
            GameObject s3 = GameObject.Find("Spawn3");
            Destroy(s3);
            GameObject b1 = GameObject.Find("BSpawn1");
            Destroy(b1);
            GameObject b2 = GameObject.Find("BSpawn2");
            Destroy(b2);
            GameObject b3 = GameObject.Find("BSpawn3");
            Destroy(b3);
            GameObject g1 = GameObject.Find("SpawnGold1");
            Destroy(g1);
            GameObject g2 = GameObject.Find("SpawnGold2");
            Destroy(g2);
            GameObject g3 = GameObject.Find("SpawnGold3");
            Destroy(g3);
        }
        */

        SpawnShopAt("ShopSpawn1"); //Had to comment out to temp. fix conflict
        SpawnShopAt("ShopSpawn2");
        SpawnShopAt("ShopSpawn3");

        SpawnWallAt("Spawn1");
        SpawnWallAt("Spawn2");
        SpawnWallAt("Spawn3");

        SpawnGoldAt("Spawn1Gold");
        SpawnGoldAt("Spawn2Gold");
        SpawnGoldAt("Spawn3Gold");

    }

    private void SpawnWallAt(string name)
    {
        if(Random.Range(0, 100) < 50)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabWall, position, Quaternion.identity);
            SceneController.walls.Add(obj);
        }
    }

    
    private void SpawnShopAt(string name)
    {
        if (Random.Range(0, 120) < 5)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabShop, position, Quaternion.identity);
            SceneController.shops.Add(obj);
        }
    }
    

    private void SpawnGoldAt(string name)
    {
        //if (Random.Range(0, 200) < 70)
        if (Random.Range(0, 200) < 125)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabGold, position, Quaternion.identity);
            SceneController.golds.Add(obj);
        }
    }



    private void OnTriggerEnter(Collider other) // AABB didnt work so I used this
    {

        if (other.gameObject.tag == "rocks")
        {
            Destroy(other.gameObject);
        }


    }

}

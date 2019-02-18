using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject prefabWall;
    public GameObject prefabGold;
    
    // Start is called before the first frame update
    void Start()
    {

        


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

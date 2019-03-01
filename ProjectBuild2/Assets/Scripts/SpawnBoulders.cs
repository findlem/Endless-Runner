using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoulders : MonoBehaviour
{

    public GameObject PrefabRock;
    public Transform Rocks; 
    private bool TriggerSpawnVar = true;
    private int SpawnVar = 0;
    private int MercySpawn = 0;
    public int Spawn_Rate = 650;

    // Start is called before the first frame update
    void Start()
    {


        


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRun.isInShop)
        {
            Spawn_Rate = 0;
        }


        if (TriggerSpawnVar == true)
        {

            SpawnVar = Random.Range(0, Spawn_Rate);
        }
        if(SpawnVar <= 100 && SpawnVar > 0)
        {
            SpawnboulderAt("Bspawn1");
            SpawnVar = Random.Range(0, Spawn_Rate);
            
        }
        if(SpawnVar > 75 && SpawnVar  <= 155)
        {
            SpawnboulderAt("Bspawn2");
            SpawnVar = Random.Range(0, Spawn_Rate);
        }
        if(SpawnVar > 155 && SpawnVar  <= 200)
        {
            SpawnboulderAt("Bspawn3");
            SpawnVar = Random.Range(0, Spawn_Rate);
        }
        if(SpawnVar > 200)
        {
            MercySpawn += 1;
            if (MercySpawn >= 300)
            {
                MercySpawn = 0;
                SpawnVar = Random.Range(0, Spawn_Rate);
            }
        }


        //print(SpawnVar);
    }

    private void SpawnboulderAt(string name)
    {
        if (Random.Range(0, 100) < .0000000001)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(PrefabRock, position, Quaternion.identity);
            SceneController.rocks.Add(obj);
        }
    }

    private void OnTriggerEnter(Collider other) // AABB didnt work so I used this
    {

        if (other.gameObject.tag == "rock")
        {
            Destroy(other.gameObject);
        }

    }

}

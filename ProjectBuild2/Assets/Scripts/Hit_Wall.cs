using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Wall : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

       

    }

    // Now using to hit boulders and walls
    private void OnCollisionEnter(Collision other)
    {
    

        if (other.gameObject.tag == "rock")
        {
            Destroy(other.gameObject);
        }
    }
    
}

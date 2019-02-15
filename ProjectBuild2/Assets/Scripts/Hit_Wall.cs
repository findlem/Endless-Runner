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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "wall")
        {
            Destroy(other.gameObject);
        }
    }
}

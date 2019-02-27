using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFlow : MonoBehaviour
{


    public float speed = 9;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.z += speed *Time.deltaTime;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRoll : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.z -= 5 * Time.deltaTime;

        transform.position = pos;

        transform.Rotate(5f,0f,0f);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(gameObject);

        }
        if (other.gameObject.tag == "shop")
        {
            Destroy(gameObject);

        }

    }

}

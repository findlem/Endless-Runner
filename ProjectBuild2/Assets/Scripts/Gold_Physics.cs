using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Physics : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {

        
        transform.Rotate(0f, 0f, -90f);


    }

    // Update is called once per frame
    void Update()
    {


        transform.Rotate(120f * Time.deltaTime, 0f, -0f);



    }
}

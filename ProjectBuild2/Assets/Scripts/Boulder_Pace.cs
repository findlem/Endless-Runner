using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Pace : MonoBehaviour
{

    private int Timer = 0;
    private float pace_speed = 1;
    // Start is called before the first frame update
    void Start()
    {
       
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Timer += 1;

        if(Timer <= 30)
        {
            pos.z += pace_speed * Time.deltaTime;
        }
        if(Timer > 30)
        {
            pos.z += -pace_speed * Time.deltaTime;
        }
        if(Timer >= 60)
        {
            Timer = 0;
        }

        transform.position = pos;

    }
}

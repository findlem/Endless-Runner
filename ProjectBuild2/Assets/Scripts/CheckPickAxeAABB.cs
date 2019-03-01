using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPickAxeAABB : MonoBehaviour
{
    ColliderAABB cb;
    PlayerRun pr;
    // Start is called before the first frame update
    void Start()
    {
        cb = GetComponent<ColliderAABB>();
        pr = GetComponent<PlayerRun>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerRun.Active == true)
        {

            cb.halfSize.z = 2.5f;
            
        }


    }
}

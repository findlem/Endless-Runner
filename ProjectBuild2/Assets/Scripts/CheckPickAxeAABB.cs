using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPickAxeAABB : MonoBehaviour
{
    ColliderAABB cb;
    
    // Start is called before the first frame update
    void Start()
    {
        cb = GetComponent<ColliderAABB>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Pickaxe_attack.Active == true)
        {

            cb.halfSize.z = 5f;
            
        }


    }
}

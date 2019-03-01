using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPickAxeAABB : MonoBehaviour
{
    ColliderAABB cb;
    Pickaxe_attack pa;
    // Start is called before the first frame update
    void Start()
    {
        cb = GetComponent<ColliderAABB>();
        pa = GetComponent<Pickaxe_attack>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pa.Active == true)
        {

            cb.halfSize.z += 0.5f;
            
        }


    }
}

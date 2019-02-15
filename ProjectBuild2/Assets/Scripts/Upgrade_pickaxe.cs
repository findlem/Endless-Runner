using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_pickaxe : MonoBehaviour
{
    public Vector3 Upgrade_axe;

    Pickaxe_attack pa;
    // Start is called before the first frame update
    void Start()
    {
        pa = GetComponent<Pickaxe_attack>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pickaxe_attack.Active == true)
        {
            Upgrade_axe = transform.localScale;

            Upgrade_axe.z = 10f; // length of pickaxe would have to do the same for box below player(10f Exaggerated)

            transform.localScale = Upgrade_axe;
            
        }

    }
}

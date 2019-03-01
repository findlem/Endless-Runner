using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_pickaxe : MonoBehaviour
{
    public Vector3 Upgrade_axe;

    PlayerRun pr;
    // Start is called before the first frame update
    void Start()
    {
        pr = GetComponent<PlayerRun>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRun.Active == true)
        {
            Upgrade_axe = transform.localScale;

            Upgrade_axe.z = 5; // length of pickaxe would have to do the same for box below player(10f Exaggerated)

            transform.localScale = Upgrade_axe;


        }

    }
}

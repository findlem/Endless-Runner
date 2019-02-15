using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Shield : MonoBehaviour
{

    Pickaxe_attack pa;
    public GameObject Dwarf_Shield;
    private float PupTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        pa = GetComponent<Pickaxe_attack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pickaxe_attack.PowerUp1 == false)
        {
            Dwarf_Shield.SetActive(false);
            SceneController.powerup1 = false;
        }

        if (Pickaxe_attack.PowerUp1 == true)
        {
            PupTimer += 1;
            Dwarf_Shield.SetActive(true);
            SceneController.powerup1 = true;
        }

        if(PupTimer >= 200)
        {
            Dwarf_Shield.SetActive(false);
            PupTimer = 0;
            Pickaxe_attack.PowerUp1 = false;
            SceneController.powerup1 = false;

        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Shield : MonoBehaviour
{

    PlayerRun pr;
    public GameObject Dwarf_Shield;
    public float PupTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        pr = GetComponent<PlayerRun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRun.PowerUp1 == false)
        {
            Dwarf_Shield.SetActive(false);
            SceneController.powerup1 = false;
        }

        if (PlayerRun.PowerUp1 == true && PlayerRun.isInShop == false && PlayerRun.PupActive == true)
        {
            PupTimer += 1;
            Dwarf_Shield.SetActive(true);
            SceneController.powerup1 = true;
        }

        if(PupTimer >= 300)
        {
            Dwarf_Shield.SetActive(false);
            PupTimer = 0;
            PlayerRun.PowerUp1 = false;
            SceneController.powerup1 = false;
            PlayerRun.PupActive = false;

        }
        
    }
}

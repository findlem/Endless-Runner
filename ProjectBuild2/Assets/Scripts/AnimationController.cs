using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator dAnimator;
    private bool isShopping = false;
    // Start is called before the first frame update
    void Start()
    {

        dAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = false;

        if (DeleteItem.currentHealth <= 0 || PlayerRun.outOfGold == true)
        {
            isDead = true;
            dAnimator.SetBool("Dead", isDead);

        }

        if (PlayerRun.isInShop == true)
        {
            isShopping = true;
            dAnimator.SetBool("Shawp", isShopping);
        }
        if (PlayerRun.isInShop == false)
        {
            isShopping = false;
            dAnimator.SetBool("Shawp", isShopping);
        }


    }
}

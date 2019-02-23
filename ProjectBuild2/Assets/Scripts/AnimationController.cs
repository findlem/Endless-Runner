using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator dAnimator;
    // Start is called before the first frame update
    void Start()
    {

        dAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = false;

        if (DeleteItem.currentHealth <= 0)
        {
            isDead = true;
            dAnimator.SetBool("Dead", isDead);

        }


    }
}

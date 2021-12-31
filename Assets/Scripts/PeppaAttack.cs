using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeppaAttack : MonoBehaviour
{
    private Animator animator;

    public bool player1;
    private KeyCode melee;
    private KeyCode sp;
    public void Start()
    {
        animator = GetComponent<Animator>();
        if (player1)
        {
            melee = KeyCode.E;
            sp = KeyCode.Q;
        }
        else
        {
            melee = KeyCode.O;
            sp = KeyCode.U;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(melee) || Input.GetKeyDown(sp))
        {
            animator.SetBool("isMelee", true);
        }
        else
        {
            animator.SetBool("isMelee", false);
        }
    }
}

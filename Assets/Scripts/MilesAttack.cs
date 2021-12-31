using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilesAttack : MonoBehaviour
{
    private Animator animator;

    public GameObject web;

    public bool player1;

    private KeyCode melee;
    private KeyCode sp;

    public ParticleSystem thump;
    public ParticleSystem electric;

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
        if (web.GetComponent<Web>().isWebbed)
        {
            animator.SetBool("isSpecial", false);
            animator.SetBool("isWebbed", true);
        }
        else
        {
            animator.SetBool("isWebbed", false);
        }


        if (Input.GetKeyDown(melee))
        {
            int num = Random.Range(1, 3);
            switch (num)
            {
                case 1:
                    animator.SetBool("isMelee1", true);
                    animator.SetBool("isMelee2", false);
                    break;
                case 2:
                    animator.SetBool("isMelee2", true);
                    animator.SetBool("isMelee1", false);
                    break;
            }       
        }
        else
        {
            animator.SetBool("isMelee1", false);
            animator.SetBool("isMelee2", false);
            if (Input.GetKeyDown(sp))
            {
                animator.SetBool("isSpecial", true);          
            }
            else
            {
                animator.SetBool("isSpecial", false);
            }
        }
    }

    public void Thump()
    {
        thump.Play();
    }
    public void Electric()
    {
        electric.Play();
    }
}

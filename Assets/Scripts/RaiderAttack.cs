using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderAttack : MonoBehaviour
{
    private Animator animator;

    public bool player1;

    private KeyCode melee;
    private KeyCode sp;

    public GameObject trap;
    public GameObject spawnpoint;

    public bool first = true;

    public float maxTime = 30;
    public float timer = 0;


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
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
        }
        if (Input.GetKeyDown(melee))
        {
                first = !first;
                if (first)
                {
                    animator.SetBool("isSwing1", true);
                    animator.SetBool("isSwing2", false);
                }
                else
                {
                    animator.SetBool("isSwing1", false);
                    animator.SetBool("isSwing2", true);
                }
        }
        else
        {
            animator.SetBool("isSwing1", false);
            animator.SetBool("isSwing2", false);

            if (Input.GetKeyDown(sp))
            {
                if (GetComponent<PlayerMove>().isGrounded && timer<=0)
                {
                    animator.SetBool("isSpecial", true);
                    StartCoroutine(SpecialAttack());
                    timer = maxTime;
                }
                else
                {
                    animator.SetBool("isSpecial", false);
                }
            }
            else
            {
                animator.SetBool("isSpecial", false);
            }
        }
    }
    IEnumerator SpecialAttack()
    {
        GameObject trapClone = Instantiate(trap, spawnpoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(maxTime);
        Destroy(trapClone);
    }
}

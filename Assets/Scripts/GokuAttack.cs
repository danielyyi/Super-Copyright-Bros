using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuAttack : MonoBehaviour
{
    private Animator animator;

    public GameObject ball;
    public GameObject spawnAndDirection;
    public float ballSpeed = 15f;
    public float ballLife = 2f;

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

    IEnumerator SpecialAttack()
    {
        GameObject ballClone = Instantiate(ball, spawnAndDirection.transform.position, Quaternion.identity);
        ballClone.GetComponent<SphereCollider>().enabled = false;
        ballClone.GetComponent<Rigidbody>().AddRelativeForce(spawnAndDirection.transform.forward * ballSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(.15f);

        ballClone.GetComponent<SphereCollider>().enabled = true;

        yield return new WaitForSeconds(ballLife);
        Destroy(ballClone);
    }
}

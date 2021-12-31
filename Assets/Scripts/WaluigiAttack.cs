using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaluigiAttack : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawnpoint;
    private Animator animator;
    public GameObject ballDirectionCube;
    public float ballSpeed = 10;
    public bool player1;
    private KeyCode melee;
    private KeyCode sp;

    public ParticleSystem poof;

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
            animator.SetBool("isMelee", true);
        }
        else
        {
            animator.SetBool("isMelee", false);
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
        GameObject ballClone = Instantiate(ball, spawnpoint.transform.position, Quaternion.identity);
        ballClone.GetComponent<Rigidbody>().AddRelativeForce(ballDirectionCube.transform.forward * ballSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        Destroy(ballClone);
    }
    public void Poof()
    {
        poof.Play();
    }
}

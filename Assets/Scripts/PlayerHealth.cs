using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isWebbed;
    public float percent;
    private Animator animator;
    private Rigidbody rb;
    private GameObject gm;

    public int lives = 3;

    public bool isPeppa;

    public bool isCritical;
    public bool isDead;

    private bool p1;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("Game Manager");

        if (isPeppa)
        {
            p1 = GetComponent<PeppaMove>().isPlayer1;
        }
        else
        {
            p1 = GetComponent<PlayerMove>().isPlayer1;

        }


        if (p1)
        {
            gm.GetComponent<TDisplay>().ChangeP1Lives(lives);
            gm.GetComponent<TDisplay>().ChangeP1Health(percent);
        }
        else
        {
            gm.GetComponent<TDisplay>().ChangeP2Lives(lives);
            gm.GetComponent<TDisplay>().ChangeP2Health(percent);
        }

    }
    public void getHit(float damage, float stunTime, Collider collider, Vector3 direction, float knockback)
    {
        if (isPeppa)
        {
            PeppaMove p = collider.GetComponent<PeppaMove>();
            percent += damage;
            p.enabled = false;
            animator.Play("getHit");
            if (isCritical)
            {
                rb.AddForce(direction * (5000) * Time.deltaTime, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(direction * (knockback + ((percent - 1) * 2)) * Time.deltaTime, ForceMode.Impulse);  
            }
            StartCoroutine(DisablePeppa(p, stunTime));
        }
        else
        {
            PlayerMove p = collider.GetComponent<PlayerMove>();
            percent += damage;
            p.enabled = false;
            animator.Play("getHit");
            if (isCritical)
            {
                rb.AddForce(direction * (5000) * Time.deltaTime, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(direction * (knockback + ((percent - 1) * 2)) * Time.deltaTime, ForceMode.Impulse);
            }
            StartCoroutine(Disable(p, stunTime));
        }


        if (percent >= 100)
        {
            isCritical = true;
        }
        if (p1)
        {
            gm.GetComponent<TDisplay>().ChangeP1Health(percent);
        }
        else
        {
            gm.GetComponent<TDisplay>().ChangeP2Health(percent);
        }
    }

    IEnumerator Disable(PlayerMove p, float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        p.enabled = true;
        p.isKnocked = true;
    }

    IEnumerator DisablePeppa(PeppaMove p, float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        p.enabled = true;
        p.isKnocked = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Death")
        {
            
            lives--;
            gm.GetComponent<TSpawnPlayers>().Respawn(p1);
            percent = 0;

            if (p1)
            {
                gm.GetComponent<TDisplay>().ChangeP1Lives(lives);
                gm.GetComponent<TDisplay>().ChangeP1Health(percent);
            }
            else
            {
                gm.GetComponent<TDisplay>().ChangeP2Lives(lives);
                gm.GetComponent<TDisplay>().ChangeP2Health(percent);
            }
        }

    }

}

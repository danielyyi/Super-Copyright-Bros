using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandoAttack : MonoBehaviour
{
    private Animator animator;
    public bool player1;
    private KeyCode melee;
    private KeyCode sp;

    public GameObject bullet;
    public GameObject spawnpoint;
    public float bulletSpeed;
    public GameObject bulletDirectionCube;
    public float bulletLife = 1f;

    public ParticleSystem f1;
    public ParticleSystem f2;
    public ParticleSystem muzzle;

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
                StartCoroutine(Pause());
            }
            else
            {
                animator.SetBool("isSpecial", false);
            }
        }
    }

    IEnumerator Pause()
    {
        GetComponent<PlayerMove>().feet.enabled = true;
        GetComponent<PlayerMove>().enabled = false;
        
        yield return new WaitForSeconds(1.7f);
        GetComponent<PlayerMove>().enabled = true;
    }

    IEnumerator Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, spawnpoint.transform.position, Quaternion.identity);
        bulletClone.GetComponent<Rigidbody>().AddRelativeForce(bulletDirectionCube.transform.forward * bulletSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(bulletLife);
        Destroy(bulletClone);
    }

    public void Fire()
    {
        f1.Play();
        f2.Play();
    }
    public void FireStop()
    {
        f1.Stop();
        f2.Stop();
    }
    public void Muzzle()
    {
        muzzle.Play();
    }
}

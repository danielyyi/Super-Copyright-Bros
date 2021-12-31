using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public Collider notTrigger;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.Play("Trap_Init");
    }
    private void Update()
    {
        if(rb.velocity.y == 0)
        {
            rb.useGravity = false;
            notTrigger.enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("isStepped", true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("isStepped", false);
        }
        
    }
    public void Reset()
    {
        animator.SetBool("isStepped", false);
    }
}

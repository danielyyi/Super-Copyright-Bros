using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private Vector3 direction;
    private Rigidbody rb;
    public Collider feet;

    
    private float leftRot = 270;
    private float rightRot = 90;

    public float rotationSpeed = 3000;

    public float moveSpeed = 5;
    public float jumpForce = 5;
    public float jumpRaycastDistance = 1.4f;

    public bool canDoubleJump;
    public bool isGrounded;

    public bool isPlayer1;

    public bool isKnocked;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
            isKnocked = false;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }



    private void Update()
    {

        if (isKnocked)
        {
            if (isPlayer1)
            {
                if(Input.GetAxisRaw("Player1") != 0)
                {
                    isKnocked = false;
                }
            }
            else
            {
                if (Input.GetAxisRaw("Player2") != 0)
                {
                    isKnocked = false;
                }
            }
        }

        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Jump();
            }
        }
        

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (rb.velocity.x < -.1)
        {
            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && isPlayer1)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(leftRot, Vector3.up), rotationSpeed * Time.deltaTime);
                animator.SetBool("isRunning", true);
            }
            else if ((Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.J)) && !isPlayer1)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(leftRot, Vector3.up), rotationSpeed * Time.deltaTime);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

        }
        else if (rb.velocity.x > .1)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && isPlayer1)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(rightRot, Vector3.up), rotationSpeed * Time.deltaTime);
                animator.SetBool("isRunning", true);
            }
            else if ((Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.J)) && !isPlayer1)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(rightRot, Vector3.up), rotationSpeed * Time.deltaTime);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }            
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


    }


    private void FixedUpdate()
    {
        if (isKnocked)
        {
            MoveKnocked();
        }
        else
        {
            Move();
        }
        
    }


    private void Move()
    {
        if (isPlayer1)
        {
            rb.velocity = new Vector3(Input.GetAxisRaw("Player1") * (moveSpeed), rb.velocity.y, 0f);
        }
        else
        {
            rb.velocity = new Vector3(Input.GetAxisRaw("Player2") * (moveSpeed), rb.velocity.y, 0f);
        }
        
    }

    private void MoveKnocked()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
    }
    private void Jump()
    {

        if (isGrounded)
        {

            rb.AddForce(0, -rb.velocity.y, 0, ForceMode.Impulse);
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            animator.SetBool("isJumping", true);

        }
        else
        {
            if (canDoubleJump == true)
            {
                rb.AddForce(0, -rb.velocity.y, 0, ForceMode.Impulse);
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                canDoubleJump = false;
                animator.SetBool("isDoubleJumping", true);

            }
        }
    }


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] CharacterController2D controller;
    Animator animator;

    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode upKey;


    float horizontalMove = 0f;

    bool jump = false;
    bool stillJumping = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightKey))
        {
            horizontalMove = 1;
            animator.SetBool("IsRunning", true);
        }
        else if (Input.GetKey(leftKey))
        {
            horizontalMove = -1;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            horizontalMove = 0;
            animator.SetBool("IsRunning", false);
        }


        if (Input.GetKeyDown(upKey))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            StartCoroutine(LandEventWait());
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(upKey))
            stillJumping = true;

        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, stillJumping);
        jump = false;
        stillJumping = false;
      
    }

    bool canResetJump = true;

    public void OnLandEvent()
    {
        if (canResetJump)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    IEnumerator LandEventWait()
    {
        canResetJump = false;
        yield return new WaitForSeconds(0.2f);
        canResetJump = true;
    }

}

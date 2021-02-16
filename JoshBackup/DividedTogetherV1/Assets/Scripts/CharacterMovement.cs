using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] CharacterController2D controller;

    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode upKey;


    float horizontalMove = 0f;

    bool jump = false;
    bool stillJumping = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightKey))
            horizontalMove = 1;
        else if (Input.GetKey(leftKey))
            horizontalMove = -1;
        else
            horizontalMove = 0;

        if (Input.GetKeyDown(upKey))
            jump = true;

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(upKey))
            stillJumping = true;

        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, stillJumping);
        jump = false;
        stillJumping = false;
      
    }
}

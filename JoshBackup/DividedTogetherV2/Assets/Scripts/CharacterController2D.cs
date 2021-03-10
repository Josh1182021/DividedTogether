using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{

    [SerializeField] float runSpeed = 50;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [Range (0, .3f)][SerializeField] float movementSmoothing = 0.05f;

    bool grounded = false;
    Rigidbody2D m_rigidbody2D;

    bool facingRight = true;

    Vector3 velocity = Vector3.zero;

    bool isJumping = false;
    [SerializeField] bool airControll = true;
    [SerializeField] float initialJumpForce = 100;
    [SerializeField] float jumpForce = 100;
    [SerializeField] float jumpTime = 0.5f;
    float jumpTimeCounter;

    [Header("Events")]

    public UnityEvent OnLandEvent;

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        jumpTimeCounter = jumpTime;
    }

    private void FixedUpdate()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                jumpTimeCounter = jumpTime;
                OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool jump, bool stillJumping)
    {

        if (grounded || airControll)
        {
            Vector3 targetVelocity = new Vector2(move * runSpeed, m_rigidbody2D.velocity.y);
            m_rigidbody2D.velocity = Vector3.SmoothDamp(m_rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }

        if (grounded && jump)
        {
            grounded = false;
            m_rigidbody2D.AddForce(new Vector2(0f, initialJumpForce));
            isJumping = true;
        }

        if (stillJumping && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                m_rigidbody2D.AddForce(new Vector2(0f, jumpForce - jumpForce*(jumpTime - jumpTimeCounter)));
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (!stillJumping)
        {
            isJumping = false;
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}

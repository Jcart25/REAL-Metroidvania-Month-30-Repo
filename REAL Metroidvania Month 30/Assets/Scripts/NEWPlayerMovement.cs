using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NEWPlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask ground;

    private float horizontal;
    [SerializeField] public float speed = 8f;
    [SerializeField] public float jumpingPower = 16f;
    
    //Friction
    [SerializeField] public float airFriction = 0.75f;
    [SerializeField] public float groundFriction = 20f;
    
    //Gravity Modifiers
    [SerializeField] public float fallGravMult = 3f;
    [SerializeField] public float LowJumpGravMult = 2f;

    //Jump
    [SerializeField] private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;

    private bool isFacingRight = true;
    private bool isJumpHeld;

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
    private void FixedUpdate()
    {
        if(Mathf.Abs(horizontal) > 0.01f)
        {
            if (IsGrounded())
            {
                rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(horizontal * speed * airFriction, rb.linearVelocity.y);
            }
        }
        
        if(IsGrounded() && Mathf.Abs(horizontal) < 0.01f)
        {
            float newX = Mathf.MoveTowards(rb.linearVelocity.x, 0, groundFriction * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y);
        }

        if(!isFacingRight && horizontal > 0f)
        {
            Flip();
        } 
        
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if(rb.linearVelocity.y < 0f)
        {
            rb.gravityScale = fallGravMult;
        } 
        else if(rb.linearVelocity.y > 0f && !isJumpHeld)
        {
            rb.gravityScale = LowJumpGravMult;
        }
        else
        {
            rb.gravityScale = 1.0f;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if(context.canceled && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        isJumpHeld = !context.canceled;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
    }

}

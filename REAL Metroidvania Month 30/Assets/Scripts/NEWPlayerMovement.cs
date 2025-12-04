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
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            Flip();
        } 
        
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
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

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
    private float Vertical;

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

    //Attack
    [SerializeField] public GameObject AttackBox;
    [SerializeField] public bool AttackActive = false;
    [SerializeField] public float AttackDuration;
    [SerializeField] private float AttackTimer = 0;

    private bool isFacingRight = true;
    private bool isJumpHeld;

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        AttackBox.SetActive(AttackActive);
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

        //Attack
        if(AttackActive)
        {
            AttackBox.SetActive(AttackActive);
            AttackTimer -= Time.fixedDeltaTime;
        }

        if (AttackTimer < 0)
        {
            AttackActive = false;
            AttackBox.SetActive(AttackActive);
        }

        if (rb.linearVelocity.y < 0f)
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
        Vertical = context.ReadValue<Vector2>().y;
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
        transform.localScale = localScale;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            AttackActive = true;
            AttackTimer = AttackDuration;
            
            if(Vertical > 0.0f)
            {
                AttackBox.transform.localPosition = new Vector3(0, 1, 0);
                AttackBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
            } 
            else if(Vertical < 0.0f)
            {
                AttackBox.transform.localPosition = new Vector3(0, -1, 0);
                AttackBox.transform.localRotation = Quaternion.Euler(0, 0, -90);
            } 
            else
            {
                AttackBox.transform.localPosition = new Vector3(isFacingRight ? 1 : -1, 0, 0);
                AttackBox.transform.localRotation = Quaternion.Euler(0, 0, isFacingRight ? 0 : 180);
            }
        }
        
    }
}

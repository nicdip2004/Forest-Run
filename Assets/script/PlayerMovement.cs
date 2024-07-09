using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float Speed = 2f;
    public float input = 0;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask ground;
    private bool grounded;
    public Transform feet;
    public float groundcheck;

    private bool facingLeft = false;

    void Update()
    {
        
        input = Input.GetAxisRaw("Horizontal") * Speed;
        animator.SetFloat("speed", Mathf.Abs(input));
        if (input < 0)
        {
            spriteRenderer.flipX = true;
            facingLeft = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
            facingLeft = false;
        }
   

        grounded = Physics2D.OverlapCircle(feet.position, groundcheck, ground);
        if(grounded == true && Input.GetButtonDown("Jump"))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(input * Speed, playerRb.velocity.y);
        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (facingLeft)
        {
            spriteRenderer.flipX = true;
        }

    }
}

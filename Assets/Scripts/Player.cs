using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] public Sprite jumpSprite;
    [SerializeField] public Sprite idleSprite;
    [SerializeField] public bool isGrounded;
    
    
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        //Check if the player is pressing either the Space bar or the left mouse button and if the player is grounded
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGrounded == true)
        {
            Jump();
        }
        
        Movement();
    }


    void Movement()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            transform.Translate((Vector2.right * horizontalInput) * movementSpeed * Time.deltaTime);
        }
        
        UpdateAnimation(horizontalInput);
        FlipSprite(horizontalInput);
    }
    
    
    void Jump()
    {
        isGrounded = false;
        rb2d.AddForce(Vector2.up * jumpForce);
        spriteRenderer.sprite = jumpSprite;
    }
    
    public void TouchedGround()
    {
        spriteRenderer.sprite = idleSprite;
        isGrounded = true;
    }
    
    void UpdateAnimation(float horizontalInput)
    {
        
        if (horizontalInput != 0 && isGrounded) //Check if actually moving and if the player is grounded
        {
            animator.Play("Mario_Running");
        } else if (isGrounded) //If the player is not moving and is grounded
        {
            animator.Play("Mario_Idle");
        }
        else //If the player is not grounded
        {
            animator.Play("Mario_Jump");
        }
    }
    
    void FlipSprite(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        } else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class My_PlayerMovement : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalMove;
    private bool isFacingRight = true;
    public bool jump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        CheckFlip();
        UpdateJumpAnim();
        CheckIsGrounded();
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMove = context.ReadValue<Vector2>().x;
    }
    private void CheckIsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }
    private void UpdateJumpAnim()
    {
        if(isGrounded) animator.SetBool("IsJumping", false);
        else if (!isGrounded) animator.SetBool("IsJumping", true);

        if (!isGrounded && rb.velocity.y > .1f) animator.SetBool("IsFalling", false);
        else if (!isGrounded && rb.velocity.y < .1f) animator.SetBool("IsFalling", true);

        
    }
    private void InvertSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = playerSprite.transform.localScale;
        localScale.x *= -1f;
        playerSprite.transform.localScale = localScale;
    }
    private void CheckFlip()
    {
        if (!isFacingRight && horizontalMove > 0f) InvertSprite();
        else if (isFacingRight && horizontalMove < 0f) InvertSprite();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2(0, 10f); 
    public float moveSpeed;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    private Collider2D playerCollider;

    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // Move the character using Rigidbody2D
        GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
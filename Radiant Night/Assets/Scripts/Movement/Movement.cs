using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2(0, 10f); 
    public float moveSpeed;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    private Collider2D playerCollider;
    public GameObject player;
    private Animator movementAnimator;

    private bool onLeftWall, onRightWall;
    private bool isGrounded;

    private void Start()
    {
        if (!Player.model)
        {
            Player.SetGender(true, null, null, null);
        }
        player.GetComponent<SpriteRenderer>().sprite = Player.model;
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        movementAnimator = player.GetComponent<Animator>();

        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying || QuestManager.GetInstance().questSystem.gameObject.activeSelf)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);

        bool movingLeft = movement.x < 0;
        bool movingRight = movement.x > 0;

        // Move the character using Rigidbody2D
        if (movingLeft && !onLeftWall)
            GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (movingRight && !onRightWall)
            GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
        }

        //turning based on direction
        if (movingLeft)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
            
        if (movingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        if (GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            movementAnimator.Play("ashley_jumping");
        }
        else if (GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            movementAnimator.Play("ashley_walking");
        }
        else
            movementAnimator.Play("ashley_idle");
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (hit.gameObject.CompareTag("Wall"))
        {
            if (player.transform.position.x > hit.gameObject.transform.position.x)
            {
                onLeftWall = true;
            }
            else if (player.transform.position.x < hit.gameObject.transform.position.x)
            {
                onRightWall = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        else if (hit.gameObject.CompareTag("Wall"))
        {
            if (player.transform.position.x > hit.gameObject.transform.position.x)
            {
                onLeftWall = false;
            }
            if (player.transform.position.x < hit.gameObject.transform.position.x)
            {
                onRightWall = false;
            }
        }
    }
}
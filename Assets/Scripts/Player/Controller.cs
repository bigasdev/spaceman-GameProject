using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask groundLayer;
    public Transform BodyPos;
    public AudioSource jumpS;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = .25f;
    private float jumpTimer;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    
    public float gravity = 1f;
    public float fallMultiplier = 5f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = .7f;
    public Vector3 colliderOffset;

    private void Update()
    {
        onGround = Physics2D.Raycast(BodyPos.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(BodyPos.position - colliderOffset, Vector2.down, groundLength, groundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }
        
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        moveCharacter(direction.x);
        
        if(jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        modifyPhysics();
    }

    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        anim.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("vertical", rb.velocity.y);

        if ((horizontal > 0 && !facingRight || (horizontal < 0 && facingRight)))
        {
            Flip();
        }
        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
    
    void modifyPhysics()
    {
        bool ChangingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || ChangingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }

    void Jump()
    {
        jumpS.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(BodyPos.position + colliderOffset, BodyPos.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(BodyPos.position - colliderOffset, BodyPos.position - colliderOffset + Vector3.down * groundLength);
    }

    public void Die()
    {
        Score.lives -= 1;
        HUD.lifeCounter -= 1;
        Destroy(gameObject);
    }
}

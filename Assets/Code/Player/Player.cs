using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    Rigidbody2D rb;
    Animator anim;
    float dirX;
    bool facingRight = true;
    bool isGrounded;

    public float GetDirX()
    {
        if (dirX < 0)
        {
            dirX *= -1;
        }
        return dirX * 2;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use FixedUpdate for physics related operations
    }

    void FixedUpdate()
    {
        dirX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (dirX > 0.1f || dirX < -0.1f)
        {
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        FlipCharacter(dirX);
    }

    void FlipCharacter(float horizontal)
    {
        if (horizontal > 0 && !facingRight)
        {
            facingRight = true;
            transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
        else if (horizontal < 0 && facingRight)
        {
            facingRight = false;
            transform.localScale = new Vector3(-0.05f, 0.05f, 0.05f);
        }
    }

    // Method to draw gizmos in the editor
    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

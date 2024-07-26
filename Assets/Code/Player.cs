using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Animator anim;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (dirX > 0.1f || dirX < -0.1f)
        {
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }

        FlipCharacter(dirX);
    }

    void FlipCharacter(float horizontal)
    {
        if (horizontal > 0 && !facingRight)
        {
            facingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0 && facingRight)
        {
            facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {


    public float maxSpeed = 10.0f;
    public Transform groundCheck;
    public LayerMask defineGround;
    public float jumpForce = 3;

    //Private
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator an;
    private float groundCheckRadius = 0.5f;
    private bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();

    }
    private void Update()
    {
        if (Input.GetAxis("JumpPlayer2") > 0 && isGrounded)
        {
            an.SetBool("ground", false);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }

    }
    // 
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, defineGround);
        //Debug.Log("Grounded:?" + groundCheck);

        an.SetBool("ground", isGrounded);


        an.SetFloat("vspeed", rb.velocity.y);



        float movH = Input.GetAxis("HorizontalPlayer2");


        an.SetFloat("speed", Mathf.Abs(movH));

        rb.velocity = new Vector2(movH * maxSpeed, rb.velocity.y);
        if (Mathf.Abs(movH) != 0)
        {
            sr.flipX = movH < 0;

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int MaxSpeed = 50;
    public int MoveSpeed = 10;
    public int JumpHeight = 100;
    public float Velocity = 0;
    public int Acceleration = 1;
    public bool IsFalling = false;
    public bool CanJump = true;
    public bool CanMove = true;
    public bool Crouched = false;
    public KeyCode jumpkey = KeyCode.Space;
    private Animator animator;
    private SpriteRenderer spriterend;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterend = GetComponent<SpriteRenderer>();
    }
    // TODO replace this code with getting the actual collision from the ground check game object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Solid") CanJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Solid") CanJump = false;
    }
    void ShellBash() { 
        //
    }
    void Jump() {
        rb.AddForce(new Vector2(0, JumpHeight));
        CanJump = false;
    }
    // Update is called once per frame
    void Update()
    {
        Velocity = 0;
        IsFalling = false;
        animator.SetBool("moving", false);
        // handle player movement
        if (Input.GetKey(KeyCode.D) && CanMove) { Velocity = Acceleration * Time.deltaTime; spriterend.flipX = false; animator.SetBool("moving", true); } // gameObject.transform.localScale = new Vector3(1, 1); }
        if (Input.GetKey(KeyCode.A) && CanMove) { Velocity = -Acceleration * Time.deltaTime; spriterend.flipX = true; animator.SetBool("moving", true); } // gameObject.transform.localScale = new Vector3(-1, 1); }
        if (Input.GetKey(KeyCode.S)) Crouched = true;
        if (Input.GetKeyDown(jumpkey) && CanJump) Jump();
        if (Input.GetKeyUp(KeyCode.S)) Crouched = false;
        // move the player with whatever means you wish
        rb.AddForce(new Vector2(Velocity, 0) * MoveSpeed);
        if (rb.velocity.magnitude > MaxSpeed) rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        if (rb.velocity.y < 0) IsFalling = true;
        // if (Input.GetKey(KeyCode.D) ) { spriterend.flipX = false; animator.SetBool("Run", true); } // gameObject.transform.localScale = new Vector3(1, 1); }
    }
}

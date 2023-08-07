using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Logic : MonoBehaviour
{
    public float FollowBias = 5;
    public bool FollowingPlayer = false;
    public bool CanJump = false;
    public int JumpHeight = 450;
    public float AttentionSpan;
    public GameObject player;
    private float MaxSpeed = 9;
    private float JumpTimer = 5;
    private float Interia = 0;
    private bool IsFalling = false;
    private Vector2 MoveDir = Vector2.zero;
    private Vector2 OldMoveDir = Vector2.zero;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    float Distance(Vector2 v1, Vector2 v2) {
        return Mathf.Sqrt(Mathf.Pow((v2.x - v1.x),2) + Mathf.Pow((v2.y - v1.y), 2));
    }
    void FindDirPlayer() {
        if (player.transform.position.x < transform.position.x) { 
            MoveDir = -transform.right;
            spriteRenderer.flipX = true;
        }
        if (player.transform.position.x > transform.position.x) { 
            MoveDir = transform.right;
            spriteRenderer.flipX = false;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Distance(player.transform.position, transform.position) < FollowBias || FollowingPlayer) { 
            FindDirPlayer();
            FollowingPlayer = true;
        }
    }
    void Jump()
    {
        rb.AddForce(new Vector2(0, JumpHeight));
        CanJump = false;
    }
    void Update()
    {
        IsFalling = false;
        Debug.DrawLine(MoveDir.normalized, MoveDir.normalized + MoveDir.normalized);
        rb.AddForce(MoveDir.normalized * 10 * Interia);
        if (rb.velocity.magnitude > MaxSpeed) rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        if (FollowingPlayer) {
            AttentionSpan -= Time.deltaTime;
        }
        if (Distance(player.transform.position, transform.position) < FollowBias) AttentionSpan = 5;
        if (rb.velocity.y < 0) IsFalling = true;
        if (rb.velocity.y == 0) CanJump = true;
        if (Distance(player.transform.position, transform.position) < FollowBias && JumpTimer <= 0 && IsFalling == false) Jump();
        if (AttentionSpan <= 0)
        {
            FollowingPlayer = false;
            MoveDir = Vector2.zero;
        }
        if (Vector2.Dot(OldMoveDir, MoveDir) > 0 && Interia < 1) {
            Interia += Time.deltaTime;
        }
        if (Vector2.Dot(OldMoveDir, MoveDir) < 0) {
            Interia = 0;
        }
        if (Interia > 1) Interia = 1;
        JumpTimer -= Time.deltaTime;
        OldMoveDir = MoveDir;
    }
}

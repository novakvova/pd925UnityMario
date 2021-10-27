using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField] private LayerMask jumpbleGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MoventState { idle, running, jumping, falling}
    
    private float dirX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);
        //Debug.Log("Horizontal "+ dirX.ToString());
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpateAnimatorState();
    }
    void UpateAnimatorState()
    {
        MoventState state;
        if (dirX > 0f)
        {
            state = MoventState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MoventState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MoventState.idle;
        }
        if(rb.velocity.y>.1f)
        {
            state = MoventState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MoventState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    
    bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, 
            Vector2.down, .1f, jumpbleGround);
    }
}

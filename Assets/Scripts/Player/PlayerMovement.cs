using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{



    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private float MoveSpeed = 7f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState{idle,running,jumping,falling }
    // private MovementState state = MovementState.idle;

    private float sideX = 0;

    // For Audio
    [SerializeField] private AudioSource jumpSoundEffect;



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sideX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(sideX * MoveSpeed, rb.velocity.y);

   

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            
        }

        updateanimation();

    }
    //   private void Movement()
    // {
    //     if (Input.GetButtonDown("Jump") && IsGrounded())
    //     {
    //         jumpSoundEffect.Play();
    //         rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            
    //     }
    // }

    private void updateanimation()
    {
        MovementState state;

        if (sideX > 0)
        {
            // anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (sideX < 0)
        {
            // anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            //anim.SetBool("running", false);
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f )
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state",(int) state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f, Vector2.down, .1f, jumpableGround);
    }

    
}

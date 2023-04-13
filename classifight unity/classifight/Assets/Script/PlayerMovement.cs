using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rg;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f; 
    private float MoveSpeed = 7f;
    private float JumpForce = 14f;
    private MovementState state;
    private enum MovementState { idle, running, jumping, falling, attacking, jmpattacking }
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rg.velocity = new Vector2(dirX * MoveSpeed, rg.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg.velocity = new Vector2(dirX * rg.velocity.x, JumpForce);
        }
        Move();
        if ((Input.GetKeyDown(KeyCode.J)))
        {
            state = MovementState.attacking;
            anim.SetInteger("state", (int)state);
        }    
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            state = MovementState.attacking;
        }    
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rg.velocity.y > .1f)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                state = MovementState.jmpattacking;
            }
            else
            {
                state = MovementState.jumping;
            }
        }
        else if (rg.velocity.y < -.1f)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                state = MovementState.jmpattacking;
            }
            else
            {
                state = MovementState.falling;
            }
        }
        anim.SetInteger("state", (int)state);
    }
}

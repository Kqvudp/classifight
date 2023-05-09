using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rg;
    private float dirX = 0f;
    private float MoveSpeed = 7f;
    private bool checkJump = false;
    [SerializeField] private float JumpForce = 14f;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rg.velocity = new Vector2(dirX * MoveSpeed, rg.velocity.y);
        checkJump = Input.GetKeyDown(KeyCode.Space);

        if (checkJump )
        {
            rg.velocity = new Vector2(dirX * rg.velocity.x, JumpForce);
        }
    }
}

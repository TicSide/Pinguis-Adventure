using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDeslice : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField] int jumpower;
    [SerializeField] float fallMultiplier;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 vecGravity;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position,new Vector2(0.3f, 2.05f),CapsuleDirection2D.Vertical,0,groundLayer);
        if (Input.GetButtonDown("Jump")&&isGrounded) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpower);
        }

        if ( rigidbody2D.velocity.y<0)
        {
            rigidbody2D.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }
}

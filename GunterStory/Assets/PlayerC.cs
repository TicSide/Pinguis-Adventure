using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f; 
    private bool isGrounded = true; 

    private bool hasItem = false;

    public GameObject objectToActivate1;
    public GameObject objectToActivate2;

    public GameObject collectibleItem;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("El jugador necesita un rb.");
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E) && !hasItem && collectibleItem != null)
        {
            PickUpItem();
        }
    }

    private void Jump()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        }
    }

    private void PickUpItem()
    {
        Debug.Log("Objeto recogido.");
        hasItem = true;

        collectibleItem.SetActive(false);

        if (objectToActivate1 != null) objectToActivate1.SetActive(true);
        if (objectToActivate2 != null) objectToActivate2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == collectibleItem)
        {
            Debug.Log("Cerca del objeto recolectable. Presiona 'E' para recogerlo.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

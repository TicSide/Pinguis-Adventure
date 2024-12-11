using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingControl : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 2f; 
    [SerializeField] private float acceleration = 0.1f; 
    private Rigidbody2D rb;
    private float currentSpeed = 0f; 
    private float radio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No se encontro un Rigidbody2D");
        }
    }

    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }


        Vector2 velocity = rb.velocity;
        velocity.x = currentSpeed; 
        rb.velocity = velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bloque"))
        {
            currentSpeed = 2f;
        }
    }



}

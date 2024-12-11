using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle; 
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (particle != null)
        {
            particle.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sprite != null)
            {
                sprite.enabled = false;
            }

            if (particle != null)
            {
                particle.Play();
            }
        }
    }
}

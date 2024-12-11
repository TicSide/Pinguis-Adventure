using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle; 
    [SerializeField] ParticleSystem fallParticle;     
    [SerializeField] ParticleSystem touchParticle;   

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod; 

    [SerializeField] Rigidbody2D playerRb; 

    private float counter; 
    private bool isFalling;
  
    private void Update()
    {

        if (!(PlayerHealth.health <= 0))
        {
            counter += Time.deltaTime;

            if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
            {
                if (counter > dustFormationPeriod)
                {
                    if (!movementParticle.isPlaying)
                    {
                        movementParticle.Play();
                    }
                    counter = 0;
                }
            }
            else
            {
                if (movementParticle.isPlaying)
                {
                    movementParticle.Stop();
                }
            }

            if (playerRb.velocity.y < -0.1f)
            {
                if (!fallParticle.isPlaying)
                {
                    fallParticle.Play();
                }
                isFalling = true;
            }
            else
            {
                if (isFalling)
                {
                    fallParticle.Stop();
                    isFalling = false;
                }
            }

        }

        if (PlayerHealth.health <= 0) {
            touchParticle.Stop();
            movementParticle.Stop();
            fallParticle.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bloque"))
        {
            touchParticle.Play();
        }
    }


}

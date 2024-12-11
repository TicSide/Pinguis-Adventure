using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CoinManager cm;
    public AudioSource audioSource;
    public AudioClip coinClip;
    public AudioClip hurtClip;
    public AudioClip lifeClip;
    public AudioClip deathClip;
    public AudioClip winClip;
    public ParticleSystem efectomuerte;

    private CameraFollow cameraFollow; 
    private bool hasDied = false;
    public MonoBehaviour script1;
    public BoxCollider2D boxCollider;

    public GameObject canvas;
    public GameObject canvaswin;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameObject cameraObject = Camera.main.gameObject; 
        cameraFollow = cameraObject.GetComponent<CameraFollow>();

        if (cameraFollow == null)
        {
            Debug.LogError("No se encontro el CameraFollow.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.clip = coinClip;
            audioSource.Play();
            Destroy(other.gameObject);
            cm.coinCount++;
        }
        else if (other.gameObject.CompareTag("Bloque"))
        {
            audioSource.clip = hurtClip;
            audioSource.Play();
        }
        else if (other.gameObject.CompareTag("MoreLife"))
        {
            audioSource.clip = lifeClip;
            audioSource.Play();
        }
        if (other.gameObject.CompareTag("Win"))
        {
            audioSource.clip = winClip;
            audioSource.Play();

            cm.coinCount++;

            canvaswin.SetActive(true);
            Debug.Log("Game Over!");
            if (script1 != null)
            {
                script1.enabled = false;
            }
            if (cameraFollow != null)
            {
                cameraFollow.enabled = false;
            }
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }

        }



        if (PlayerHealth.health <= 0 && !hasDied)
        {
            hasDied = true; 
            audioSource.clip = deathClip;
            audioSource.Play();
            efectomuerte.Play();
            canvas.SetActive(true);
            Debug.Log("Game Over!");
            if (script1 != null)
            {
                script1.enabled = false;
            }
            if (cameraFollow != null)
            {
                cameraFollow.enabled = false;
            }
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }

        }
    }
}

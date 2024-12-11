using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGame: MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    private AudioSource audiosource;

    private void Start()
    {
    
            audiosource = GetComponent<AudioSource>();
            if (audiosource == null)
            {
                Debug.LogError("AudioSource no asignado .");
            }
    
        if (sceneController == null)
        {
            sceneController = FindObjectOfType<SceneController>();
            if (sceneController == null)
            {
                Debug.LogError("SceneController no encontrado en la escena.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.tag == "Player" && sceneController != null)
        {
            audiosource.Play();
            sceneController.PlayGame();
        }
    }
}

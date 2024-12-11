using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public float transitionTime = 1f;

    private void Start()
    {
        // Obtener el componente Animator automáticamente
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator no asignado o no encontrado en el GameObject.");
        }
    }

    // Carga la escena del juego
    public void PlayGame()
    {
        PlayerHealth.ResetHealth(); // Restablecer la salud antes de iniciar el juego
        LoadNextScene();
    }

    // Salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    // Cargar la siguiente escena por índice
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    // Cargar una escena por nombre
    public void LoadSceneByName(string sceneName)
    {
        PlayerHealth.ResetHealth(); // Restablecer la salud antes de cargar la escena
        StartCoroutine(SceneLoadByName(sceneName));
    }

    // Corrutina para cargar la escena por índice
    private IEnumerator SceneLoad(int nextSceneIndex)
    {
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Corrutina para cargar la escena por nombre
    private IEnumerator SceneLoadByName(string sceneName)
    {
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}

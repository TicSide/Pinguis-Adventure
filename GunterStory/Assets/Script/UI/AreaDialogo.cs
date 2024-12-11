using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDialogo : MonoBehaviour
{
    public GameObject TextoFlotantePrefab; // Referencia al objeto de texto flotante
    private bool textoMostrado = false; // Variable para asegurarte de que solo se active una vez
    private AudioSource audiosource;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        if (audiosource == null)
        {
            Debug.LogError("AudioSource no asignado o no encontrado en el GameObject.");
        }
    }
    private void OnTriggerEnter2D(Collider2D cl)
    {


        if (cl.tag == "Player" && !textoMostrado) // Verifica si el texto no ha sido mostrado aún
        {
            audiosource.Play();
            textoMostrado = true; // Marca que el texto ya fue mostrado
            TextoFlotantePrefab.SetActive(true); // Activa el texto
            StartCoroutine(DesactivarTexto()); // Inicia el temporizador para desactivarlo
        }
    }

    private IEnumerator DesactivarTexto()
    {
        yield return new WaitForSeconds(4f); // Espera 4 segundos
        TextoFlotantePrefab.SetActive(false); // Desactiva el texto
        textoMostrado = false; // Permite que el texto pueda activarse nuevamente si el jugador entra otra vez
    }
}

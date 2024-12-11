using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDesActivate;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisi0n d");

            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                objectToDesActivate.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No se ha asignado ningunb objeto para activar.");
            }
        }
    }
}

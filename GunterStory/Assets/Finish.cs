using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject canvaswin;
    public MonoBehaviour script1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvaswin.SetActive(true);
        if (script1 != null)
        {
            script1.enabled = false;
        }
    
    }
}

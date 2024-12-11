using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private bool canTakeDamage = true; 
    private HashSet<Collider2D> processedColliders = new HashSet<Collider2D>(); 
 


    void Start()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (processedColliders.Contains(collision))
        {
            return
        }
        processedColliders.Add(collision);

        if (canTakeDamage)
        {
            if (collision.transform.tag == "Bloque")
            {

                StartCoroutine(TakeDamage(1));
            }
            else if (collision.transform.tag == "MuerteInst")
            {
                StartCoroutine(TakeDamage(PlayerHealth.health));
            }
            else if (collision.transform.tag == "MoreLife")
            {

                PlayerHealth.health++;
            }
        }

    }

    private IEnumerator TakeDamage(int damage)
    {
        canTakeDamage = false; 
        PlayerHealth.health -= damage;

        if (PlayerHealth.health <= 0)
        {
          //  Debug.Log("Game Over!");
        }

        yield return new WaitForSeconds(0.5f); 
        canTakeDamage = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (processedColliders.Contains(collision))
        {
            processedColliders.Remove(collision);
        }
    }
}

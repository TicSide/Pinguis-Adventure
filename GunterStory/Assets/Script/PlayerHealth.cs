using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 3; 

    public Image[] Hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public static void ResetHealth()
    {
        health = 3;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, Hearts.Length);

        foreach (Image img in Hearts)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {
            Hearts[i].sprite = fullHeart;
        }
    }
}

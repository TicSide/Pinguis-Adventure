using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI cointText;

    void Start()
    {

    }

    void Update()
    {

        cointText.text = ": " + coinCount.ToString();
    }
}

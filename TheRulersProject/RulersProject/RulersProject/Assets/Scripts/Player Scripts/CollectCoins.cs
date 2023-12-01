using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoins : MonoBehaviour
{
    public int CoinsValue;
    public TextMeshProUGUI coinstext;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            Destroy(other);
            CoinsValue += 1;
            CoinsValue.ToString();
        }
    }
}

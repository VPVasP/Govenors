using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlEnabler : MonoBehaviour
{
    public GameObject bowl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats.instance.currentHealth = PlayerStats.instance.maxHealth;
            PlayerStats.instance.healthBar.SetMaxHealth(PlayerStats.instance.currentHealth);
            bowl.SetActive(true);
        }
    }
}

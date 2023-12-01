using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Animator playerAnim;
    public PlayerController movement;
    public ComboSystem comboSystem;
    public static PlayerStats instance;
    public GameObject DeadPanel;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        comboSystem = GetComponent<ComboSystem>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if(currentHealth <= 0)
        {
            movement.enabled = false;
            comboSystem.enabled = false;
            playerAnim.SetBool("IsDead",true);
            Invoke("ShowPanel", 5f);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    void ShowPanel()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        DeadPanel.SetActive(true);
    }
}


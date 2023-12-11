using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;
    public HealthBar healthBar;
    [SerializeField] private Animator anim;
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
       anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(currentHealth <= 0)
        {
            movement.enabled = false;
            comboSystem.enabled = false;
           anim.SetBool("IsDead",true);
            Invoke("ShowPanel", 5f);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
      //  anim.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
    }
    void ShowPanel()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        DeadPanel.SetActive(true);
    }
}


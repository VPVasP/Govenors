using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystats : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;
    public EnemyHealthBar healthBar;
    public GameManager ourManager;
    public Animator enemyAnim;
    public AudioSource enemyHurt;
    public IdleAI ai;
    public Patrolling pat;
    public AIStateManager aiStates;
    public Collider col;
    private void Start()
    {
        col = GetComponent<Collider>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void Losehealth(int damage)
    {
        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            enemyAnim.SetBool("IsDead", true);
            currentHealth = 0;
            if (currentHealth == 0)
            {
                ourManager.GainCoins();
                Destroy(col);
                Destroy(aiStates);
                Destroy(ai);
                Destroy(pat);
                Destroy(this.gameObject, 3f);
            }
        }
        healthBar.SetHealth(currentHealth);
    }
}
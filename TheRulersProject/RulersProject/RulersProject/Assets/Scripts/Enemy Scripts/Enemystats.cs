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
    public IdleAI ai;
    public Patrolling pat;
    public AIStateManager aiStates;
    public Collider col;
    [SerializeField] private AudioSource aud;
    private void Start()
    {
        if (aud == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
            
        }
        aud.loop = false;
        aud.playOnAwake = false;
        col = GetComponent<Collider>();
        aud = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void Losehealth(int damage)
    {
        currentHealth -= damage;
        aud.clip = SoundEffectsManager.instance.enemyAttackSound;
        aud.Play();
        //healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            enemyAnim.SetBool("IsDead", true);
            currentHealth = 0;
            if (currentHealth <= 0)
            {
                aud.clip = SoundEffectsManager.instance.enemyDeathSound;
                aud.Play();
             float   gainCoinsCurrency = Random.Range(2, 5);
                ourManager.GainCoins(gainCoinsCurrency);
                GameManager.instance.UpdateEnemyKillCount();
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
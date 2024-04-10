using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health;
    public int worth = 50;
    [Header("Unity Stuff")]
    public GameObject enemyDeathParticles;
    public Image healthBar;
    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(enemyDeathParticles, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    }

    
}

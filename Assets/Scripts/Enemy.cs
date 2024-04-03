using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 50;
    public GameObject enemyDeathParticles;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(enemyDeathParticles, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public static int EnemiesAlive = 0;

    public Transform spawnPoint;
    public Transform waveRoot;
    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI waveText;
    public GameManager gameManager;
    public float nextWave = 5.5f;
    private float countdown = 0;
    private int waveNumber = 0;

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if(waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            enabled = false;
        }
        //BEFORE STARTING THE NEXT WAVE ADD A START BUTTON HERE SO THE PLAYER HAS TIME TO SET UP
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = nextWave;
            return;
        }else{
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            countdown -= Time.deltaTime;
            waveCountDownText.text = string.Format("{0:00.00}", countdown);
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Waves++;
        Wave wave = waves[waveNumber];
        EnemiesAlive = wave.enemies.Length;
        waveText.text = $"Wave: {waveNumber.ToString("00")}";
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            SpawnEnemy(wave.enemies[i]);
            yield return new WaitForSeconds(1 / wave.spawnRate);
            
        }
        waveNumber++;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, waveRoot);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform waveRoot;
    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI waveText;
    public float nextWave = 5.5f;
    private float countdown = 0;
    private int waveNumber = 0;


    void Start()
    {
        
    }

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = nextWave;
        }else{
            waveCountDownText.text = $"Time: {countdown.ToString("0")}";
            countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        waveText.text = $"Wave: {waveNumber.ToString("00")}";
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
            
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, waveRoot);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    

    public Text txt_WaveCountdownTimer;
    private int waveIndex = 0;
    void Update(){
        if (countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            
        }
        countdown -= Time.deltaTime;
        txt_WaveCountdownTimer.text = ("Next Wave in : " + Mathf.Round(countdown)).ToString();
    }

    IEnumerator SpawnWave(){
        waveIndex++;
        HealthSystem.countRounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}

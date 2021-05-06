using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 5.0f;
    private int enemyCount;
    private int waveNumber = 1;

    private void Update() {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount <= 0) {
            SpawnEnemyWave(waveNumber++);  
            Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPosition(){
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        return new Vector3(spawnPosX,1,spawnPosZ);
    }
}

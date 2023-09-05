using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnPos = 9;
    private Vector3 spawnPosY = new Vector3(0, 0.5f, 0);
    public int enemyCount;
    public int waveNumber = 1;
   

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition() + spawnPosY, powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        

        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition ()
    {
        float spawnPosX = Random.Range(-spawnPos, spawnPos);
        float spawnPosZ = Random.Range(-spawnPos, spawnPos);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        
        /* Должно было создавать шары разного размера
        GameObject enemyScale = GameObject.Find("Enemy");
        float randomScale = Random.Range(0.1f, 1.0f);
        Vector3 scaleChange = new Vector3(randomScale, randomScale, randomScale);
        enemyScale.transform.localScale += scaleChange;
        */

        for (int i=0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            
        }
    }
}


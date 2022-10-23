using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject candy;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnRadius = 7f;
    [SerializeField] private float totalEnemies = 10f;
    [SerializeField] private float spawnInterval = 2.5f;

    
    void Start()
    {
        SpawnEnemy();
    }


    async void SpawnEnemy()
    {
        for (int i = 0; i < totalEnemies; ++i)
        {
            Vector2 spawnPosition = candy.transform.position; 
            spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            Debug.LogFormat("Spawned enemy at time {0}", Time.time);
            await Task.Delay((int)(spawnInterval * 1000));
        }
        Debug.LogFormat("Finished spawning enemies at {0}", Time.time);
    }

}

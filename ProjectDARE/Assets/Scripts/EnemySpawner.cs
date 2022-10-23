using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject candy;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameController gameController;

    public async Task<bool> SpawnEnemy(float spawnRadius, int totalEnemies, float spawnIntervalmin, float spawnIntervalmax)
    {
        float spawnInterval;
        Vector2 spawnPosition = candy.transform.position; 
        for (int i = 0; i < totalEnemies; ++i)
        {
            spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            Debug.LogFormat("Spawned enemy at time {0}", Time.time);
            gameController.addToEnemies(1);
            spawnInterval = Random.Range(spawnIntervalmin, spawnIntervalmax);
            await Task.Delay((int)(spawnInterval * 1000));
        }
        Debug.LogFormat("Finished spawning enemies at {0}", Time.time);
        return true;
    }

}

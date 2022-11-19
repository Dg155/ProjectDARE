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
        float timeBefore;
        for (int i = 0; i < totalEnemies; ++i)
        {
            spawnPosition = candy.transform.position;
            while (((spawnPosition.x > -5) && (spawnPosition.x < 4)) || ((spawnPosition.y > -4) && (spawnPosition.y < 5))) {spawnPosition = spawnPosition + (Random.insideUnitCircle.normalized * spawnRadius);}
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            gameController.addToEnemies(1);
            spawnInterval = Random.Range(spawnIntervalmin, spawnIntervalmax);
            timeBefore = 0f;
            while (timeBefore < spawnInterval) {timeBefore += Time.deltaTime; await Task.Yield();}
        }
        return true;
    }

}

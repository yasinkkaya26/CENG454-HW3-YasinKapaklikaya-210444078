using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int enemiesPerWave = 3;
    [SerializeField] private float spawnRadius = 8f;
    [SerializeField] private float spawnDelay = 1f;

    public void SpawnWave(int waveNumber)
    {
        StartCoroutine(SpawnEnemiesWithDelay(waveNumber));
    }

    private IEnumerator SpawnEnemiesWithDelay(int waveNumber)
    {
        int count = enemiesPerWave + (waveNumber - 1) * 2;

        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(prefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}

using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int enemyCountPerWave = 5;
    [SerializeField] private float spawnRadius = 8f;

    public void SpawnWave(int waveNumber)
    {  
        int count = enemyCountPerWave + (waveNumber - 1)*2;

        for(int i = 0; i<count; i++)
        {
            Vector2 spawnPos = Random.insideUnitCircle.normalized*spawnRadius;
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
        
    }
}

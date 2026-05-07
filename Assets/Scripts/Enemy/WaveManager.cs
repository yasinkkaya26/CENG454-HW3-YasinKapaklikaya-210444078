using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int wavesTotal = 3;
    [SerializeField] private float timeBetweenWaves = 5f;

    private int currentWave = 0;

    public UnityEvent<int> onWaveStarted;
    public UnityEvent onAllWavesCompleted;

    private void Start()
    {
        StartCoroutine(StartWaves());
    }


    private IEnumerator StartWaves()
    {
        while (currentWave < wavesTotal)
        {
            currentWave++;
            onWaveStarted?.Invoke(currentWave);
            Debug.Log($"Wave {currentWave} started!");

            yield return new WaitForSeconds(timeBetweenWaves);
        }

        onAllWavesCompleted?.Invoke();
        Debug.Log("All waves completed - Player wins!");
    }
}
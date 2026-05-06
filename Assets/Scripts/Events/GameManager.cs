using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public bool isGameOver = false;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void OnCoreDepleted()
    {  
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("Game Over - Core Destroyed");
    }

    public void OnWaveCompleted()
    {
        Debug.Log("Wave Completed");
    }
}

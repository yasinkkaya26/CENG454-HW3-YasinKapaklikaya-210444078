using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private UIManager uiManager;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void OnCoreDepleted()
    {
        if (isGameOver) return;
        isGameOver = true;
        uiManager.ShowGameOver();
    }

    public void OnWaveCompleted()
    {
        if (isGameOver) return;
        uiManager.ShowWin();
    }
}
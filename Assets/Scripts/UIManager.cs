using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TMP_Text coreHealthText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void ShowWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UpdateCoreHealth(float maxHealth)
    {
        if (coreHealthText != null)
        coreHealthText.text = $"Core HP: {Mathf.RoundToInt(maxHealth)}";    
    }
}
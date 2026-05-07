using UnityEngine;
using UnityEngine.Events;

public class CoreHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 3000f;
    [SerializeField] private UIManager uiManager;
    private float currentHealth;

    public UnityEvent OnCoreDepleted;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        uiManager?.UpdateCoreHealth(currentHealth);

        if (currentHealth <= 0)
        {
            OnCoreDepleted?.Invoke();
        }
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }
}
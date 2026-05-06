using UnityEngine;
using UnityEngine.Events;

public class CoreHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnCoreDepleted;

    private void Awake()
    {
        currentHealth = maxHealth;
    } 


    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth/maxHealth);

        if (currentHealth <= 0)
        {
            OnCoreDepleted.Invoke();
        }
    }


    public float getHealthPercent()
    {
        return currentHealth / maxHealth;
    }
}

using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth = 30f;
    [SerializeField] protected float moveSpeed = 2f;

    protected float currentHealth;
    protected Transform target;
    public bool IsDead { get; private set; }

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Start()
    {
        GameObject core = GameObject.FindWithTag("Core");

        if (core != null)
        target = core.transform;
    }

    public void TakeDamage(float amount)
    {
        if (IsDead) return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            IsDead = true;
            Die();
        }
    }

    protected virtual void Die()
        {
            gameObject.SetActive(false);
        }
}

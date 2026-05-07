using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth = 30f;
    [SerializeField] protected float moveSpeed = 2f;

    protected float currentHealth;
    protected Transform target;

    private IMoveStrategy moveStrategy;

    public bool IsDead { get; private set; }

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        moveStrategy = GetComponent<IMoveStrategy>();
    }

    protected virtual void Start()
    {
        GameObject core = GameObject.FindWithTag("Core");
        if (core != null)
            target = core.transform;
    }

    protected virtual void Update()
    {
        if (IsDead) return;
        moveStrategy?.Execute(transform, target, moveSpeed);
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
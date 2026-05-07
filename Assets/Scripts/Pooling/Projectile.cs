using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifetime = 3f;

    private Vector2 direction;
    private ObjectPool pool;
    private float timer;

    public void Init(Vector2 dir, ObjectPool returnPool)
    {
        direction = dir.normalized;
        pool = returnPool;
        timer = 0f;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= lifetime)
            ReturnToPool();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        pool?.Return(gameObject);
    }
}
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private ObjectPool projectilePool;
    [SerializeField] private float fireRate = 0.3f;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer >= fireRate)
        {
            fireTimer = 0f;
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

        GameObject bullet = projectilePool.Get();
        bullet.transform.position = transform.position;

        Projectile projectile = bullet.GetComponent<Projectile>();
        projectile.Init(direction, projectilePool);
    }
}
using UnityEngine;

public class BasicWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField] private ObjectPool projectilePool;

    public float GetDamage() => damage;
    public float GetFireRate() => fireRate;

    public void Fire(Vector2 direction)
    {
        GameObject bullet = projectilePool.Get();
        bullet.transform.position = transform.position;

        Projectile projectile = bullet.GetComponent<Projectile>();
        projectile.Init(direction, projectilePool);
    }
}
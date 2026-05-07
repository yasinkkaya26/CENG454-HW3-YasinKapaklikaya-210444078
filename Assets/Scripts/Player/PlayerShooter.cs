using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private BasicWeapon basicWeapon;
    [SerializeField] private float fireTimer;

    private IWeapon currentWeapon;

    private void Start()
    {
        // Başlangıçta basic silah
        currentWeapon = basicWeapon;
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer >= currentWeapon.GetFireRate())
        {
            fireTimer = 0f;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            currentWeapon.Fire(direction);
        }
    }

    // Hız upgrade'i ekle
    public void ApplySpeedUpgrade(float multiplier)
    {
        currentWeapon = new SpeedDecorator(currentWeapon, multiplier);
        Debug.Log("Speed upgrade applied!");
    }

    // Hasar upgrade'i ekle
    public void ApplyDamageUpgrade(float bonus)
    {
        currentWeapon = new DamageDecorator(currentWeapon, bonus);
        Debug.Log("Damage upgrade applied!");
    }
}
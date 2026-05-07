using UnityEngine;

public class WeaponUpgradePickup : MonoBehaviour
{
    public enum UpgradeType { Speed, Damage }

    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private float upgradeValue = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerShooter shooter = other.GetComponent<PlayerShooter>();
        if (shooter != null)
        {
            if (upgradeType == UpgradeType.Speed)
                shooter.ApplySpeedUpgrade(upgradeValue);
            else
                shooter.ApplyDamageUpgrade(upgradeValue);

            gameObject.SetActive(false);
        }
    }
}
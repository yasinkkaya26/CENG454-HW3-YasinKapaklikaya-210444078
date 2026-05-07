public class SpeedDecorator : WeaponDecorator
{
    private float speedMultiplier;

    public SpeedDecorator(IWeapon weapon, float multiplier) : base(weapon)
    {
        speedMultiplier = multiplier;
    }

    public override float GetFireRate() => wrapped.GetFireRate() / speedMultiplier;
}
public class DamageDecorator : WeaponDecorator
{
    private float damageBonus;

    public DamageDecorator(IWeapon weapon, float bonus) : base(weapon)
    {
        damageBonus = bonus;
    }

    public override float GetDamage() => wrapped.GetDamage() + damageBonus;
}
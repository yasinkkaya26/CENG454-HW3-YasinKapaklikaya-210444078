public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon wrapped;

    public WeaponDecorator(IWeapon weapon)
    {
        wrapped = weapon;
    }

    public virtual float GetDamage() => wrapped.GetDamage();
    public virtual float GetFireRate() => wrapped.GetFireRate();
    public virtual void Fire(UnityEngine.Vector2 direction) => wrapped.Fire(direction);
}

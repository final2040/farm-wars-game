using UnityEngine;

public class ProjectileFireParams
{
    public ProjectileFireParams(int damage, float knockbackForce)
    {
        Damage = damage;
        KnockbackForce = knockbackForce;
    }

    public int Damage { get; private set; }
    public float KnockbackForce { get; private set; }
}
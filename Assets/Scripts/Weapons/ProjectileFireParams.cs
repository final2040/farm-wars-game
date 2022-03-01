using UnityEngine;

public class ProjectileFireParams
{
    public ProjectileFireParams(Vector3 position, int damage, float knockbackForce)
    {
        Position = position;
        Damage = damage;
        KnockbackForce = knockbackForce;
    }

    public Vector3 Position { get; private set; }
    public int Damage { get; private set; }
    public float KnockbackForce { get; private set; }
}
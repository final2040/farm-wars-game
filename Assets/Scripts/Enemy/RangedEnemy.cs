using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private Projectile projectilePrefab;

    protected override void ApplyDamage()
    {
        var projectle = Instantiate(projectilePrefab, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        projectle.Fire(new ProjectileFireParams(target.transform.position, strength, knockBackForce), Constants.PlayerTag);
    }
}
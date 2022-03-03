using UnityEngine;

public class RangedEnemy : Enemy
{
    private const int ProjectileYAxisOffset = 1;

    [SerializeField] private Projectile projectilePrefab;

    protected override void ApplyDamage()
    {
        var projectle = Instantiate(projectilePrefab, new Vector3(transform.position.x, ProjectileYAxisOffset, transform.position.z), transform.rotation);
        projectle.Fire(new ProjectileFireParams(strength, knockBackForce), Constants.PlayerTag);
    }
}
using UnityEngine;

public class RangedWeapon : Weapon
{
    private const int YPositionOffset = 1;
    [SerializeField] private Projectile projectile;

    protected override void OnAttackStart()
    {
        
    }

    public override void OnEndAttack()
    {
        var projectle = Instantiate(projectile, new Vector3(transform.position.x, YPositionOffset, transform.position.z), transform.rotation);
        projectle.Fire(new ProjectileFireParams(attackPower, weaponKnockBack), Constants.EnemyTag);
    }
}
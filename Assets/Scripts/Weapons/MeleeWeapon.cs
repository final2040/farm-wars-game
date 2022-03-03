using UnityEngine;


public class MeleeWeapon : Weapon
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && IsAtacking)
        {
            var enemy = other.gameObject.GetComponent<Character>();
            enemy.ReceiveDamage(attackPower, this);
        }
    }

    protected override void OnAttackStart()
    {
        col.enabled = true;
    }

    public override void OnEndAttack()
    {
        IsAtacking = false;
        col.enabled = false;
    }
}
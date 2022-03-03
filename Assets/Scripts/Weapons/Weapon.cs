using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider))]
public abstract class Weapon : MonoBehaviour, IDamageDealer
{
    protected Animator anim;
    protected Collider col;
    protected float cooldown;
    protected bool IsAtacking;

    [SerializeField] protected float attackTime = 1f;
    [SerializeField] protected int attackPower = 3;
    [SerializeField] protected float weaponKnockBack = 10;

    public bool CanAttack => cooldown <= 0;
    public float KnockbackForce => weaponKnockBack;
    public Vector3 CurrentPosition => transform.position;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
    }

    protected virtual void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public virtual void Attack()
    {
        if (cooldown <= 0)
        {
            PlayAnimation();
            IsAtacking = true;
            cooldown = attackTime;
            OnAttackStart();
        }
    }

    protected abstract void OnAttackStart();

    protected virtual void PlayAnimation()
    {
        anim.SetTrigger("Attack");
    }

    public abstract void OnEndAttack();
}
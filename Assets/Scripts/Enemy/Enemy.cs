using UnityEngine;

public class Enemy : Character, IDamageDealer
{
    [SerializeField] protected Character target;
    [SerializeField] protected float attackRange;
    [SerializeField] protected int strength = 5;
    [SerializeField] protected float swingTime = 0.5f;
    [SerializeField] protected float knockBackForce;
    [SerializeField] protected int pointsValue;

    private float lastAttack = 0;

    public Vector3 CurrentPosition => transform.position;
    public float KnockbackForce => knockBackForce;


    protected override void OnUpdate()
    {
        if (IsAlive)
        {
            FollowTarget();
            Attack();
            transform.LookAt(target.transform.position);
            lastAttack += Time.deltaTime;
        }
    }

    private void FollowTarget()
    {
        if (!TargetIsInRange())
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    private void Attack()
    {
        if (lastAttack > swingTime && TargetIsInRange())
        {
            ApplyDamage();
            lastAttack = 0;
        }
    }

    protected virtual void ApplyDamage()
    {
        target.ReceiveDamage(strength, this);
    }


    bool TargetIsInRange()
    {
        var distance = Vector3.Distance(transform.position, target.transform.position);
        return distance < attackRange;
    }

    protected override void Die()
    {
        GameManager.Instance.AddScore(pointsValue);
        Destroy(gameObject);
    }


    public void SetTarget(Character target)
    {
        this.target = target;
    }

}
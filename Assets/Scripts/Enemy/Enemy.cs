using UnityEngine;

public class Enemy : Character, IDamageDealer
{
    [SerializeField] private Character target;
    [SerializeField] private float attackRange;
    [SerializeField] private int strength = 5;
    [SerializeField] private float swingTime = 0.5f;
    [SerializeField] private float knockBackForce;
    private float lastAttack = 0;

    public Vector3 CurrentPosition => transform.position;
    public float KnockbackForce => knockBackForce;


    protected override void Die()
    {
        Destroy(gameObject);
    }

    protected override void Update()
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
            target.ReceiveDamage(strength, this);
            lastAttack = 0;
        }
    }


    bool TargetIsInRange()
    {
        var distance = Vector3.Distance(transform.position, target.transform.position);
        return distance < attackRange;
    }

    public void SetTarget(Character target)
    {
        this.target = target;
    }

}

using UnityEngine;

public class Enemy : Character, IDamageDealer
{
    [SerializeField] private Character target;
    [SerializeField] private float attackRange;
    [SerializeField] private float strength = 5.0f;
    [SerializeField] private float swingTime = 0.5f;
    [SerializeField] private float knockBackForce;
    private float lastAttack = 0;

    public Vector3 CurrentPosition => transform.position;
    public float KnockbackForce => knockBackForce;


    protected override void Update()
    {
        if (!TargetIsInRange())
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }

        if (TargetIsInRange())
        {
            Attack();
        }

        lastAttack += Time.deltaTime;
        transform.LookAt(target.transform.position);
    }

    private void Attack()
    {
        if (lastAttack > swingTime)
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

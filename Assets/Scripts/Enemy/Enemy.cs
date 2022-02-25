using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private Character target;
    [SerializeField] private float attackRange;
    [SerializeField] private float strength = 5.0f;
    [SerializeField] private float swingTime = 0.5f;
    private float lastAttack = 0;


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
            var direction = target.transform.position - transform.position;
            target.ReceiveDamage(strength, direction);
            lastAttack = 0;
        }
    }


    bool TargetIsInRange()
    {
        var distance = Vector3.Distance(transform.position, target.transform.position);
        return distance < attackRange;
    }
}

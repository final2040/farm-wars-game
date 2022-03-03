using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider))]
public class Weapon : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int attackPower = 3;
    [SerializeField] private float attackTime = 1f;
    [SerializeField] private float weaponKnockBack = 10;
    private float cooldown;
    private Animator animator;
    private Collider collider;
    private bool IsAtacking;

    public bool CanAttack => cooldown <= 0;
    public float KnockbackForce => weaponKnockBack;
    public Vector3 CurrentPosition => transform.position;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (cooldown <= 0)
        {
            IsAtacking = true;
            cooldown = attackTime;
            collider.enabled = true;
            Swing();
        }
    }

    private void Swing()
    {
        animator.SetTrigger("Attack");
    
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && IsAtacking)
        {
            var enemy = other.gameObject.GetComponent<Character>();
            enemy.ReceiveDamage(attackPower, this);
        }
    }

    public void EndAttack()
    {
        IsAtacking = false;
        collider.enabled = false;
    }

   
}

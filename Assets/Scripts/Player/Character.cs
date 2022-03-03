using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] private HealtBar healtBar;
    [SerializeField] protected int maxLife;

    protected Rigidbody myRigidbody;
    protected IMainManager mainManager;
    protected int life;

    public bool IsAlive => life > 0;

    public int MaxLife
    {
        get => maxLife;
        set
        {
            maxLife = value;
            OnMaxLifeUpdated();
        }
    }

    public int Life
    {
        get => life;
        set
        {
            if (life != value)
            {
                UpdateLife(value);
            }
        }
    }

    protected void UpdateLife(int value)
    {
        if (value > maxLife)
        {
            life = maxLife;
        }
        else if (value <= 0)
        {
            life = 0;
            Die();
        }
        else
        {
            life = value;
        }
        healtBar?.UpdateBar((float)Life / (float)maxLife);
        OnLifeUpdated();
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    protected abstract void Die();

    protected void Awake()
    {
        OnAwake();
    }

    protected void Start()
    {
        mainManager = MainManager.Instance;
        myRigidbody = GetComponent<Rigidbody>();
        life = maxLife;
        OnStart();
    }

    protected void Update()
    {
        OnUpdate();
    }

    protected virtual void OnAwake() { }

    protected virtual void OnStart() { }

    protected virtual void OnUpdate() { }

    public virtual void ReceiveDamage(int ammount, IDamageDealer damageDealer)
    {
        if (IsAlive)
        {
            Life -= ammount;
            ApplyKnockBack(damageDealer);
            SpawnManager.Create.DamageIndicator().Show(gameObject, ammount, Color.red);
        }
    }

    public virtual void Heal(int ammount)
    {
        Life += ammount;
        SpawnManager.Create.DamageIndicator().Show(gameObject, ammount, Color.green);
    }

    protected virtual void OnLifeUpdated() { }
    protected virtual void OnMaxLifeUpdated() { }


    private void ApplyKnockBack(IDamageDealer damageDealer)
    {
        var positionDiference = transform.position - damageDealer.CurrentPosition;
        var knockBackDirection = new Vector3(positionDiference.x, 0, positionDiference.z).normalized;
        myRigidbody.AddForce(knockBackDirection * damageDealer.KnockbackForce, ForceMode.Impulse);
    }
}
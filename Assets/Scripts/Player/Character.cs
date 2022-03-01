using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, INotifyPropertyChanged
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
        set => maxLife = value;
    }

    public int Life
    {
        get => life;
        set
        {
            if (life != value)
            {
                OnPropertyChanged();
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
    }

    protected abstract void Die();

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

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
            SpawnManager.Create.DamageIndicator().Show(gameObject, ammount);
        }

        OnReceiveDamage();
    }

    protected virtual void OnReceiveDamage() { }


    private void ApplyKnockBack(IDamageDealer damageDealer)
    {
        var positionDiference = transform.position - damageDealer.CurrentPosition;
        var knockBackDirection = new Vector3(positionDiference.x, 0, positionDiference.z).normalized;
        Debug.Log(knockBackDirection);
        myRigidbody.AddForce(knockBackDirection * damageDealer.KnockbackForce, ForceMode.Impulse);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody myRigidbody;
    protected IMainManager mainManager;

    public float Life { get; set; } = 100;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        mainManager = MainManager.Instance;
        myRigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {

    }

    public virtual void ReceiveDamage(float ammount, IDamageDealer damageDealer)
    {
        Life -= ammount;
        ApplyKnockBack(damageDealer);
        Debug.Log($"Taking Damage {gameObject.name} life left  {Life}");
    }

    private void ApplyKnockBack(IDamageDealer damageDealer)
    {
        var positionDiference = transform.position - damageDealer.CurrentPosition;
        var knockBackDirection = new Vector3(positionDiference.x, 0, positionDiference.z).normalized;
        Debug.Log(knockBackDirection);
        myRigidbody.AddForce(knockBackDirection * damageDealer.KnockbackForce, ForceMode.Impulse);
    }
}

public class Player : Character
{
    [SerializeField] private Sword weapon;

    protected override void Awake()
    {
        base.Awake();
    }


    public Sword Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    protected override void Update()
    {
        var horizontalAxis = Input.GetAxis(mainManager.Controls.HorizontalAxis);
        var verticalAxis = Input.GetAxis(mainManager.Controls.VerticalAxis);


        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            myRigidbody.velocity = (Vector3.right * horizontalAxis * speed) + (Vector3.forward * verticalAxis * speed);
            
        }
        

        if (Input.GetKeyDown(mainManager.Controls.Attack))
        {
            if (Weapon.CanAttack)
            {
                Weapon.Attack();
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float receiveDamageKnockBackForce;
    protected Rigidbody rigidbody;
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
        rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {

    }

    public void ReceiveDamage(float ammount, Vector3 direction)
    {
        Life -= ammount;
        ApplyKnockBack(direction);
        Debug.Log($"Taking Damage life left {Life}");
    }

    private void ApplyKnockBack(Vector3 direction)
    {
        rigidbody.AddRelativeForce(direction * receiveDamageKnockBackForce, ForceMode.Impulse);
    }
}

public class Player : Character
{
    protected override void Update()
    {
        var horizontalAxis = Input.GetAxis(mainManager.Controls.HorizontalAxis);
        var verticalAxis = Input.GetAxis(mainManager.Controls.VerticalAxis);

        rigidbody.velocity = (Vector3.right * horizontalAxis * speed) + (Vector3.forward * verticalAxis * speed);

    }
}

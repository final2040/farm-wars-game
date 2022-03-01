using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Camera gameCamera;
    private Vector3 mouseWorldPosition;


    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }

    protected override void Update()
    {
        HandleMovement();
        HandleAttack();
        HandlePlayerFacingRotation();
    }

    private void HandlePlayerFacingRotation()
    {
        mouseWorldPosition = gameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            gameCamera.transform.position.y));
        transform.LookAt(mouseWorldPosition);
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(mainManager.Controls.Attack))
        {
            if (Weapon.CanAttack)
            {
                Weapon.Attack();
            }
        }
    }

    private void HandleMovement()
    {
        var horizontalAxis = Input.GetAxis(mainManager.Controls.HorizontalAxis);
        var verticalAxis = Input.GetAxis(mainManager.Controls.VerticalAxis);


        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            myRigidbody.velocity = (Vector3.right * horizontalAxis * speed) + (Vector3.forward * verticalAxis * speed);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(mouseWorldPosition, 1);
    }
}

using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Camera gameCamera;
    private Vector3 mouseWorldPosition;


    public Weapon MeleeWeapon
    {
        get => weapon;
        set => weapon = value;
    }

    protected override void OnStart()
    {
        UpdateUiLife();
    }

    protected override void OnReceiveDamage()
    {
        UpdateUiLife();
    }

    protected override void OnUpdate()
    {
        HandleMovement();
        HandleAttack();
        HandlePlayerFacingRotation();
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

    private void HandleAttack()
    {
        if (Input.GetKeyDown(mainManager.Controls.Attack))
        {
            if (MeleeWeapon.CanAttack)
            {
                MeleeWeapon.Attack();
            }
        }
    }

    private void HandlePlayerFacingRotation()
    {
        mouseWorldPosition = gameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            gameCamera.transform.position.y));
        transform.LookAt(mouseWorldPosition);
    }

    protected override void Die()
    {
        GameManager.Instance.GameOver();
    }

    private void UpdateUiLife()
    {
        GameManager.Instance.UpdatePlayerLife(life, maxLife);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(mouseWorldPosition, 1);
    }
}

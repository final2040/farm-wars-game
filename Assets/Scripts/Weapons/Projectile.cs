using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed;
    private Vector3 targetPosition;
    private string targetType;
    private int damage;
    private bool isFired;
    private float knockback;

    public void Fire(ProjectileFireParams projectileFireParams, string type)
    {
        targetType = type;
        targetPosition = projectileFireParams.Position;
        damage = projectileFireParams.Damage;
        knockback = projectileFireParams.KnockbackForce;
        transform.LookAt(new Vector3(targetPosition.x, 2, targetPosition.z));
        isFired = true;
    }

    private void Update()
    {
        if (isFired)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetType))
        {
            var target = other.gameObject.GetComponent<Character>();
            target.ReceiveDamage(damage, this);
            Destroy(gameObject);
        }
    }


    public float KnockbackForce => knockback;

    public Vector3 CurrentPosition => transform.position;
}

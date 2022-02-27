using UnityEngine;

public interface IDamageDealer
{
    float KnockbackForce { get; }
    Vector3 CurrentPosition { get; }
}
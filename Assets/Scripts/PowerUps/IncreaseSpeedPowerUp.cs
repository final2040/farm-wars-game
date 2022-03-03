using System.Collections;
using UnityEngine;

public class IncreaseSpeedPowerUp : PowerUp
{
    [SerializeField] private float duration;
    [SerializeField] private float speedPercentage;
    
    private float originalSpeed;
    private Player player;
    
    protected override void Deliver(Player player)
    {
        this.player = player;
        originalSpeed = player.Speed;
        player.Speed *= 1 + speedPercentage / 100;
        gameObject.transform.position = new Vector3(0, -10, 0);
        StartCoroutine(EndEffect());
    }

    private IEnumerator EndEffect()
    {
        yield return new WaitForSeconds(duration);
        player.Speed = originalSpeed;
        Destroy(gameObject);
    }
}
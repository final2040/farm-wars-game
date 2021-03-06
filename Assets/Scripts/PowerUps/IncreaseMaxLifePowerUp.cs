using UnityEngine;

public class IncreaseMaxLifePowerUp : PowerUp
{
    [SerializeField] public int lifeAmmount;
    protected override void Deliver(Player player)
    {
        player.MaxLife += lifeAmmount;
        player.Heal(player.MaxLife);
        Destroy(gameObject);
    }
}
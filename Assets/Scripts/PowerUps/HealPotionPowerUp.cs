using UnityEngine;

public class HealPotionPowerUp : PowerUp
{
    [SerializeField] public int healtAmmount;
    protected override void Deliver(Player player)
    {
        player.Heal(healtAmmount);
        Destroy(gameObject);
    }
}
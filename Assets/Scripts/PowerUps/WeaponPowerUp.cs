using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class WeaponPowerUp : PowerUp
{
    [SerializeField] private Weapon weapon;

    protected override void Deliver(Player player)
    {
        DestroyOldWeapon(player);
        EquipNewWeapon(player);
        Destroy(gameObject);
    }

    private void EquipNewWeapon(Player player)
    {
        var newWeapon = Instantiate(weapon, player.transform.position, player.transform.rotation);
        newWeapon.transform.parent = player.transform;
        player.MeleeWeapon = newWeapon;
    }

    private static void DestroyOldWeapon(Player player)
    {
        var currentWeapon = player.MeleeWeapon;
        Destroy(currentWeapon.gameObject);
        player.MeleeWeapon = null;
    }
}
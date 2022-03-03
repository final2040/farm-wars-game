using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class WeaponPowerUp : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private int activationCooldown = 2;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(activationCooldown);
        col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
            var player = other.GetComponent<Player>();
            Deliver(player);
            Destroy(gameObject);
        }
    }

    private void Deliver(Player player)
    {
        DestroyOldWeapon(player);
        EquipNewWeapon(player);
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

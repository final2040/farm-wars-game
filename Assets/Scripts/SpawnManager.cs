using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private DamageIndicator damageIndicatorPrefab;

    public static SpawnManager Create { get; private set; }



    private void Awake()
    {
        if (Create == null)
        {
            Create = this;
        }
    }

    public DamageIndicator DamageIndicator()
    {
        return Instantiate(damageIndicatorPrefab);
    }
}

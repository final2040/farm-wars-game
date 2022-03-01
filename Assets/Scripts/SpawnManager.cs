using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const int SpawnOffset = 3;
    [SerializeField] private DamageIndicator damageIndicatorPrefab;
    [SerializeField] private Enemy[] enemies;

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

    public void EnemyWave(int number, Character target)
    {
        for (int i = 0; i < number; i++)
        {
            var enemyIndex = Random.Range(0, enemies.Length);
            var enemy = Instantiate(enemies[enemyIndex], CreateRandomCoordinate(), enemies[enemyIndex].transform.rotation);
            enemy.SetTarget(target);
        }
    }

    private Vector3 CreateRandomCoordinate()
    {
        //todo: find a better way to spawn randomly outside camera visible coordinates
        Vector3 coordinate;
        do
        {
            var position = Random.Range(1, 4);
            var x = 0f; 
            var z = 0f;
            switch (position)
            {
                case 1:
                    x = Random.Range(MainCamera.Instance.VisibleCoordinates.Right, MainCamera.Instance.VisibleCoordinates.Left);
                    z = MainCamera.Instance.VisibleCoordinates.Top + SpawnOffset;
                    break;
                case 2:
                    x = Random.Range(MainCamera.Instance.VisibleCoordinates.Right, MainCamera.Instance.VisibleCoordinates.Left);
                    z = MainCamera.Instance.VisibleCoordinates.Bottom - SpawnOffset;
                    break;
                case SpawnOffset:
                    x = MainCamera.Instance.VisibleCoordinates.Left - SpawnOffset;
                    z = Random.Range(MainCamera.Instance.VisibleCoordinates.Top, MainCamera.Instance.VisibleCoordinates.Bottom);
                    break;
                case 4:
                    x = MainCamera.Instance.VisibleCoordinates.Left + SpawnOffset;
                    z = Random.Range(MainCamera.Instance.VisibleCoordinates.Top, MainCamera.Instance.VisibleCoordinates.Bottom);
                    break;
            }
            coordinate = new Vector3(x, 0, z);
        } while (!GameManager.Instance.WorldBounds.Contains(coordinate));

        return coordinate;
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const int SpawnOffset = 3;
    [SerializeField] private DamageIndicator damageIndicatorPrefab;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private WeaponPowerUp[] weapons;
    [SerializeField] private PowerUp[] powerUps;

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

    public void Wave(int number, Character target)
    {
        for (int i = 0; i < number; i++)
        {
            var enemyIndex = Random.Range(0, enemies.Length);
            var enemy = Instantiate(enemies[enemyIndex], CreateRandomCoordinate(), enemies[enemyIndex].transform.rotation);
            enemy.SetTarget(target);
        }

        PowerUp();
        Weapon();
    }

    private void Weapon()
    {
        var weaponIndex = Random.Range(0, weapons.Length);
        var coords = CreateRandomCoordinatesInCamera();
        var weapon = weapons[weaponIndex];

        Instantiate(weapon, new Vector3(coords.x, weapon.transform.position.y, coords.z), weapon.transform.rotation);
    }

    private void PowerUp()
    {
        var powerUpIndex = Random.Range(0, weapons.Length);
        var coords = CreateRandomCoordinatesInCamera();
        var powerUp = powerUps[powerUpIndex];
        Instantiate(powerUp, new Vector3(coords.x, powerUp.transform.position.y, coords.z), powerUp.transform.rotation);
    }

    private Vector3 CreateRandomCoordinatesInCamera()
    {
        var x = Random.Range(MainCamera.Instance.VisibleCoordinates.Left, MainCamera.Instance.VisibleCoordinates.Right);
        var z = Random.Range(MainCamera.Instance.VisibleCoordinates.Bottom, MainCamera.Instance.VisibleCoordinates.Top);
        return new Vector3(x, 0, z);
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

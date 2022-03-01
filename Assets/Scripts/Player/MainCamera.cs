using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera Instance { get; private set; }

    [SerializeField] private GameObject target;
    [SerializeField] private float verticalLimit = 50;
    [SerializeField] private float horizontalLimit = 50;

    public ViewableArea VisibleCoordinates => new ViewableArea(transform.position,
        new Vector2(GetComponent<Camera>().orthographicSize * 1.77f, GetComponent<Camera>().orthographicSize));

    void Awake()
    {
        verticalLimit -= GetComponent<Camera>().orthographicSize;
        horizontalLimit -= GetComponent<Camera>().orthographicSize * 1.77f;
        Instance = this;
    }

    void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        var xDestination = target.transform.position.x;
        var zDestination = target.transform.position.z;
        var yDestination = transform.position.y;

        if (zDestination > verticalLimit || zDestination < -verticalLimit)
        {
            zDestination = transform.position.z;
        }

        if (xDestination > horizontalLimit || xDestination < -horizontalLimit)
        {
            xDestination = transform.position.x;
        }

        transform.position = new Vector3(xDestination, yDestination, zDestination);
    }
}


public class ViewableArea
{
    public float Top { get; set; }
    public float Left { get; set; }
    public float Right { get; set; }
    public float Bottom { get; set; }
    public Vector3 Center { get; set; }

    public ViewableArea(Vector3 center, Vector2 size)
    {
        Top = center.z + size.y;
        Bottom = center.z - size.y;
        Left = center.x - size.x;
        Right = center.x + size.x;
        Center = center;
    }

    public override string ToString()
    {
        return $"Top: {Top}, " +
               $"Bottom: {Bottom}, " +
               $"Left: {Left}, " +
               $"Right: {Right}, ";
    }
}

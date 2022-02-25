using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float verticalLimit = 50;
    [SerializeField] private float horizontalLimit = 50;

    void Awake()
    {
        verticalLimit -= GetComponent<Camera>().orthographicSize;
        horizontalLimit -= GetComponent<Camera>().orthographicSize * 1.77f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHockeyHandle : MonoBehaviour
{
    public Vector2 rangeX = new Vector2(-0.35f, 0.35f);
    public Vector2 rangeZ = new Vector2(-0.88f, -0.38f);
    public float MouseSensitivity = 10;

    Vector3 initialPosition;


    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        float newX = transform.position.x + mouseMovement.x * MouseSensitivity * Time.deltaTime;
        newX = Mathf.Clamp(newX, rangeX.x, rangeX.y);

        float newZ = transform.position.z + mouseMovement.y * MouseSensitivity * Time.deltaTime;
        newZ = Mathf.Clamp(newZ, rangeZ.x, rangeZ.y);

        transform.position = new Vector3(newX, initialPosition.y, newZ);
    }
}

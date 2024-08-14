using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cameraParent;

    public float MouseSensitivity = 10;
    public float MovementSpeed = 10;

    Vector3 prevMousePos;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        prevMousePos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 force = Vector3.zero;

        // Add force based on input
        if (Input.GetKey(KeyCode.W))
        {
            force += transform.forward * MovementSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            force += -transform.forward * MovementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            force += -transform.right * MovementSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            force += transform.right * MovementSpeed;
        }

        // Apply the force to the Rigidbody
        rigidBody.AddForce(force, ForceMode.Force);

        // Handle mouse look rotation
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        // Rotate pitch
        float rotationDelta = mouseMovement.y * -1f * MouseSensitivity * Time.deltaTime;
        float newRotation = cameraParent.transform.localRotation.eulerAngles.x + rotationDelta;

        // Convert the rotation to the range -180 to 180
        if (newRotation > 180) newRotation -= 360;

        newRotation = Mathf.Clamp(newRotation, -40, 40);

        cameraParent.transform.localRotation = Quaternion.Euler(newRotation, 0, 0);

        // Rotate Yaw
        float yawRotation = mouseMovement.x * MouseSensitivity * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(0, rigidBody.rotation.eulerAngles.y + yawRotation, 0);
        rigidBody.MoveRotation(targetRotation);

        prevMousePos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    }

}

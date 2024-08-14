using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cameraParent;

    public float MouseSensitivity = 10;
    public float MovementSpeed = 10;

    Vector3 prevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        prevMousePos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime, Space.Self);
        }

        // Lookat direction

        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        // Rotate pitch
        float rotationDelta = mouseMovement.y * -1f * MouseSensitivity * Time.deltaTime;
        float newRotation = cameraParent.transform.localRotation.eulerAngles.x + rotationDelta;

        // Convert the rotation to the range -180 to 180
        if (newRotation > 180) newRotation -= 360;

        newRotation = Mathf.Clamp(newRotation, -40, 40);

        cameraParent.transform.localRotation = Quaternion.Euler(newRotation, 0, 0);

        //cameraParent.transform.Rotate(mouseMovement.y * -1f * MouseSensitivity * Time.deltaTime, 0, 0);
        //cameraParent.transform.rotation.


        // Rotate Yaw
        transform.Rotate(Vector3.up, mouseMovement.x * MouseSensitivity * Time.deltaTime, Space.World);

        prevMousePos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    }
}

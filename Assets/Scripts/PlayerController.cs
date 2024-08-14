using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cameraParent;
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
            transform.Translate(Vector3.forward * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.1f, Space.Self);
        }

        // Lookat direction

        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        // Rotate pitch
        cameraParent.transform.Rotate(mouseMovement.y * -1f, 0, 0);

        // Rotate Yaw
        transform.Rotate(Vector3.up, mouseMovement.x, Space.World);

        prevMousePos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 10f;
    // Separate horizontal and vertical sensitivity. Tweak these in the Inspector.
    public float horizontalSensitivity = 10f;
    public float verticalSensitivity = 2f;
    // If true, moving the mouse up will look down and vice-versa.
    public bool invertY = false;

    public Transform playerCamera; // drag the camera here in the Inspector

    float xRotation = 0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevent player from tipping over
        Cursor.lockState = CursorLockMode.Locked; // lock cursor in center
    }

    void Update()
    {
        Look();
        Move();
    }

    void Look()
    {
        // Use raw mouse axis multiplied by separate sensitivities
        float mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity;
        if (invertY) mouseY = -mouseY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate camera up/down
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotate body left/right
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }
}


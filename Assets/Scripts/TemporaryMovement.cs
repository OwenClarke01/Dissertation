using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryMovement : MonoBehaviour
{
    // Speed Settings
    public float moveSpeed = 3f; // Speed of movement
    public float rotationSpeed = 100f; // Speed of rotation

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // Ensure kinematic is set in Start() just in case
    }

    void Update()
    {
        // Get input for movement (WASD or Arrow keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);  // Move the XR Rig manually

        // Rotate the XR Rig with Q/E keys
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

}

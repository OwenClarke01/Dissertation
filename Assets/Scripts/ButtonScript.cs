using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonScript : MonoBehaviour
{
    [Header("References")]
    public InputActionProperty customAction;
    public InputActionProperty customAction2;
    public Transform xrControllerLeft; // The left XR controller's Transform
    public Transform xrControllerRight; // The right XR controller's Transform
    public LayerMask buttonLayer; // Layer for buttons

    [Header("Settings")]
    public float maxDistance = 10f; // Max interaction distance


    private void Update()
    {
        // Check raycast from the left controller
        if (Physics.Raycast(xrControllerLeft.position, xrControllerLeft.forward, out RaycastHit hitLeft, maxDistance, buttonLayer))
        {
            HandleButtonHit(hitLeft);
        }

        // Check raycast from the right controller
        if (Physics.Raycast(xrControllerRight.position, xrControllerRight.forward, out RaycastHit hitRight, maxDistance, buttonLayer))
        {
            HandleButtonHit(hitRight);
        }
    }

    private void HandleButtonHit(RaycastHit hit)
    {
        GameObject hitObject = hit.collider.gameObject;

        // Check if the hit object is a button
        if (hitObject.CompareTag("Button"))
        {
            // Check for button press
            //if (customAction.action.triggered || customAction2.action.triggered)
            {
                // Call the button's trigger method
                //hitObject.GetComponent<FloatingButton>().OnButtonPressed();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FullButtonScript : MonoBehaviour
{
    public GameObject uiToDestroy; // Reference to the UI parent GameObject
    public void OnButtonPress()
    {
        if (uiToDestroy != null)
        {
            Destroy(uiToDestroy); // Destroy the entire UI GameObject
            Debug.Log("UI destroyed after button press!");
        }
        else
        {
            Debug.LogWarning("UI GameObject not assigned.");
        }
    }
}


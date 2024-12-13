using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerScript : MonoBehaviour
{
    public Transform player; // The player's camera or XR Rig Transform

    private void Update()
    {
        if (player != null)
        {
            // Make the flat face of the cube face the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Optional: Keep the button upright
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}

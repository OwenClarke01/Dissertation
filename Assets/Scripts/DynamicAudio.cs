using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAudio : MonoBehaviour
{
    // Audio Sources
    public AudioSource leftSpeaker;
    public AudioSource rightSpeaker;
    public AudioSource crowdAudioSource;

    // Player
    public Transform player;

    // Stage Settings
    public Transform stage;
    public float stageFocusDistance = 10f;

    void Update()
    {
        if (player == null || stage == null) return;

        // Adjust the crowd volume based on distance
        float crowdDistance = Vector3.Distance(player.position, crowdAudioSource.transform.position);
        crowdAudioSource.volume = Mathf.Clamp01(1.0f - (crowdDistance / crowdAudioSource.maxDistance));

        // Adjust the band audio panning based on player position
        float pan = Mathf.Clamp((player.position.x - stage.position.x) / stageFocusDistance, -1.0f, 1.0f);
        leftSpeaker.panStereo = -Mathf.Abs(pan); // Focus left
        rightSpeaker.panStereo = Mathf.Abs(pan); // Focus right
    }
}

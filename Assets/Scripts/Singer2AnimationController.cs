using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer2AnimationController : MonoBehaviour
{
    public Animator sing2Animator;
    public AudioSource songAudioSource;
    public float sing2StartTime1 = 10f;
    public float sing2StopTime1 = 30f;

    private bool hasStartedSing21 = false;
    private bool hasStoppedSing21 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First singing section
        if (!hasStartedSing21 && currentPlayTime >= sing2StartTime1)
        {
            sing2Animator.SetTrigger("StartSing2");
            hasStartedSing21 = true;
        }

        if (!hasStoppedSing21 && currentPlayTime >= sing2StopTime1)
        {
            sing2Animator.SetTrigger("StopSing2");
            hasStoppedSing21 = true;
        }
    }
}

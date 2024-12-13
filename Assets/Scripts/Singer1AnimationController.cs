using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer1AnimationController : MonoBehaviour
{
    public Animator sing1Animator;
    public AudioSource songAudioSource;
    public float sing1StartTime1 = 10f;
    public float sing1StopTime1 = 30f;

    private bool hasStartedSing11 = false;
    private bool hasStoppedSing11 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First singing section
        if (!hasStartedSing11 && currentPlayTime >= sing1StartTime1)
        {
            sing1Animator.SetTrigger("StopDance1");
            hasStartedSing11 = true;
        }

        if (!hasStoppedSing11 && currentPlayTime >= sing1StopTime1)
        {
            sing1Animator.SetTrigger("StartDance1");
            hasStoppedSing11 = true;
        }
    }
}

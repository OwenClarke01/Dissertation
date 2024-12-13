using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer3AnimationController : MonoBehaviour
{
    public Animator sing1Animator;
    public AudioSource songAudioSource;
    public float sing3StartTime1 = 10f;
    public float sing3StopTime1 = 30f;

    private bool hasStartedSing31 = false;
    private bool hasStoppedSing31 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First singing section
        if (!hasStartedSing31 && currentPlayTime >= sing3StartTime1)
        {
            sing1Animator.SetTrigger("StopDance3");
            hasStartedSing31 = true;
        }

        if (!hasStoppedSing31 && currentPlayTime >= sing3StopTime1)
        {
            sing1Animator.SetTrigger("StartDance3");
            hasStoppedSing31 = true;
        }
    }
}

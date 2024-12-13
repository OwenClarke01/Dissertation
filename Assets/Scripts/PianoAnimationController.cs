using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoAnimationController : MonoBehaviour
{
    public Animator pianoAnimator;
    public AudioSource songAudioSource;
    public float pianoStartTime1 = 10f;
    public float pianoStopTime1 = 30f;

    private bool hasStartedPiano1 = false;
    private bool hasStoppedPiano1 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First drumming section
        if (!hasStartedPiano1 && currentPlayTime >= pianoStartTime1)
        {
            pianoAnimator.SetTrigger("StartPiano");
            hasStartedPiano1 = true;
        }

        if (!hasStoppedPiano1 && currentPlayTime >= pianoStopTime1)
        {
            pianoAnimator.SetTrigger("StartPiano");
            hasStoppedPiano1 = true;
        }
    }
}

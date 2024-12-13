using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcousticController : MonoBehaviour
{
    public Animator acousticAnimator;
    public AudioSource songAudioSource;
    public float acousticStartTime1 = 10f;
    public float acousticStopTime1 = 30f;
    public float acousticStartTime2 = 50f;
    public float acousticStopTime2 = 100;

    private bool hasStartedAcoustic1 = false;
    private bool hasStoppedAcoustic1 = false;
    private bool hasStartedAcoustic2 = false;
    private bool hasStoppedAcoustic2 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First rhythm section
        if (!hasStartedAcoustic1 && currentPlayTime >= acousticStartTime1)
        {
            acousticAnimator.SetTrigger("StartAcoustic");
            hasStartedAcoustic1 = true;
        }

        if (!hasStoppedAcoustic1 && currentPlayTime >= acousticStopTime1)
        {
            acousticAnimator.SetTrigger("StopAcoustic");
            hasStoppedAcoustic1 = true;
        }

        if (!hasStartedAcoustic2 && currentPlayTime >= acousticStartTime2)
        {
            acousticAnimator.SetTrigger("StartAcoustic");
            hasStartedAcoustic2 = true;
        }

        if (!hasStoppedAcoustic2 && currentPlayTime >= acousticStopTime2)
        {
            acousticAnimator.SetTrigger("StopAcoustic");
            hasStoppedAcoustic2= true;
        }
    }
}

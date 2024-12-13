using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrummerAnimationController : MonoBehaviour
{
    public Animator drummerAnimator;
    public AudioSource songAudioSource;
    public float drumStartTime1 = 10f; // Time in seconds when the drumming starts
    public float drumStopTime1 = 30f;
    public float drumStartTime2 = 50f;
    public float drumStopTime2 = 100f;
    public float drumStartTime3 = 150f;
    public float drumStopTime3 = 200f;

    private bool hasStartedDrumming1 = false;
    private bool hasStoppedDrumming1 = false;
    private bool hasStartedDrumming2 = false;
    private bool hasStoppedDrumming2 = false;
    private bool hasStartedDrumming3 = false;
    private bool hasStoppedDrumming3 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First drumming section
        if (!hasStartedDrumming1 && currentPlayTime >= drumStartTime1)
        {
            drummerAnimator.SetTrigger("StartDrumming");
            hasStartedDrumming1 = true;
        }

        if (!hasStoppedDrumming1 && currentPlayTime >= drumStopTime1)
        {
            drummerAnimator.SetTrigger("StopDrumming");
            hasStoppedDrumming1 = true;
        }

        // Second drumming section
        if (!hasStartedDrumming2 && currentPlayTime >= drumStartTime2)
        {
            drummerAnimator.SetTrigger("StartDrumming");
            hasStartedDrumming2 = true;
        }

        if (!hasStoppedDrumming2 && currentPlayTime >= drumStopTime2)
        {
            drummerAnimator.SetTrigger("StopDrumming");
            hasStoppedDrumming2 = true;
        }

        if (!hasStartedDrumming3 && currentPlayTime >= drumStartTime3)
        {
            drummerAnimator.SetTrigger("StartDrumming");
            hasStartedDrumming3 = true;
        }

        if (!hasStoppedDrumming3 && currentPlayTime >= drumStopTime3)
        {
            drummerAnimator.SetTrigger("StopDrumming");
            hasStoppedDrumming3 = true;
        }
    }
}

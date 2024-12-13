using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassAnimationController : MonoBehaviour
{
    public Animator bassAnimator;
    public AudioSource songAudioSource;
    public float bassStartTime1 = 10f;
    public float bassStopTime1 = 30f;
    public float bassStartTime2 = 50f;
    public float bassStopTime2 = 100f;
    public float bassStartTime3 = 150f;
    public float bassStopTime3 = 200f;

    private bool hasStartedBass1 = false;
    private bool hasStoppedBass1 = false;
    private bool hasStartedBass2 = false;
    private bool hasStoppedBass2 = false;
    private bool hasStartedBass3 = false;
    private bool hasStoppedBass3 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First bass section
        if (!hasStartedBass1 && currentPlayTime >= bassStartTime1)
        {
            bassAnimator.SetTrigger("StartBass");
            hasStartedBass1 = true;
        }

        if (!hasStoppedBass1 && currentPlayTime >= bassStopTime1)
        {
            bassAnimator.SetTrigger("StopBass");
            hasStoppedBass1 = true;
        }

        if (!hasStartedBass2 && currentPlayTime >= bassStartTime2)
        {
            bassAnimator.SetTrigger("StartBass");
            hasStartedBass2 = true;
        }

        if (!hasStoppedBass2 && currentPlayTime >= bassStopTime2)
        {
            bassAnimator.SetTrigger("StopBass");
            hasStoppedBass2 = true;
        }

        if (!hasStartedBass3 && currentPlayTime >= bassStartTime3)
        {
            bassAnimator.SetTrigger("StartBass");
            hasStartedBass3 = true;
        }

        if (!hasStoppedBass3 && currentPlayTime >= bassStopTime3)
        {
            bassAnimator.SetTrigger("StopBass");
            hasStoppedBass3 = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarAnimationController : MonoBehaviour
{
    public Animator guitarAnimator;
    public AudioSource songAudioSource;
    public float guitarStartTime1 = 10f;
    public float guitarStopTime2 = 100f;
    public float guitarStartTime3 = 150f;
    public float guitarStopTime3 = 200f;
    public float guitarStartTime4 = 300f;
    public float guitarStopTime4 = 350f;

    private bool hasStartedGuitar1 = false;
    private bool hasStoppedGuitar2 = false;
    private bool hasStartedGuitar3 = false;
    private bool hasStoppedGuitar3 = false;
    private bool hasStartedGuitar4 = false;
    private bool hasStoppedGuitar4 = false;

    private void Update()
    {
        if (!songAudioSource.isPlaying)
            return;

        // Calculate the current playback time with high precision
        float currentPlayTime = songAudioSource.time;

        // First guitar section
        if (!hasStartedGuitar1 && currentPlayTime >= guitarStartTime1)
        {
            guitarAnimator.SetTrigger("StartGuitar");
            hasStartedGuitar1 = true;
        }


        if (!hasStoppedGuitar2 && currentPlayTime >= guitarStopTime2)
        {
            guitarAnimator.SetTrigger("StopGuitar");
            hasStoppedGuitar2 = true;
        }

        if (!hasStartedGuitar3 && currentPlayTime >= guitarStartTime3)
        {
            guitarAnimator.SetTrigger("StartGuitar");
            hasStartedGuitar3 = true;
        }

        if (!hasStoppedGuitar3 && currentPlayTime >= guitarStopTime3)
        {
            guitarAnimator.SetTrigger("StopGuitar");
            hasStoppedGuitar3 = true;
        }

        if (!hasStartedGuitar4 && currentPlayTime >= guitarStartTime4)
        {
            guitarAnimator.SetTrigger("StartGuitar");
            hasStartedGuitar4 = true;
        }

        if (!hasStoppedGuitar4 && currentPlayTime >= guitarStopTime4)
        {
            guitarAnimator.SetTrigger("StopGuitar");
            hasStoppedGuitar4 = true;
        }
    }
}

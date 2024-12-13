using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandTimingDebug : MonoBehaviour
{
    public AudioSource songAudioSource; // Assign your AudioSource in the Inspector
    private double songStartDspTime;    // Tracks the DSP time when the song starts
    private double elapsedTime;         // Timer that counts up in real time

    void Start()
    {
        // Record the exact DSP time when the song starts
        songStartDspTime = AudioSettings.dspTime;
        Debug.Log("Song started at DSP time: " + songStartDspTime);
    }

    void Update()
    {
        // Calculate how much time has passed since the song started
        elapsedTime = AudioSettings.dspTime - songStartDspTime;

        // Log the elapsed time as a timer
        Debug.Log("Elapsed time since song start: " + elapsedTime.ToString("F2") + " seconds");
    }
}

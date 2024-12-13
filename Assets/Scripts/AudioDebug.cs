using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDebug : MonoBehaviour
{
    public AudioSource leftSpeaker;
    public AudioSource rightSpeaker;
    public AudioClip bandClip;

    private double songStartDspTime;

    void Start()
    {
        leftSpeaker.Stop();
        rightSpeaker.Stop();

        songStartDspTime = AudioSettings.dspTime;

        Debug.Log("Band sound will start after 5 seconds...");
        Invoke(nameof(PlayBandSound), 5f);
    }

    void PlayBandSound()
    {
        Debug.Log("Playing band sound at DSP time: " + AudioSettings.dspTime);

        double startTime = AudioSettings.dspTime + 0.1;
        leftSpeaker.PlayScheduled(startTime);
        rightSpeaker.PlayScheduled(startTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource crowdAudioSource;  // crowd audio source (gameobject)
    public AudioSource leftSpeaker;      // Left stage speaker 
    public AudioSource rightSpeaker;     // Right stage speaker 

    [Header("Audio Clips")]
    public AudioClip crowdClip;          // crowd
    public AudioClip bandClip;           // band

    [Header("Settings")]
    public float initialDelay = 1f;       // delay before all audio
    public float crowdFadeDuration = 3f; // time (seconds) for crowd to fade
    public float bandStartDelay = 2f;    // delay before band starts after crowd cheering

    private double bandStartDspTime;     // dsp time when band starts

    void Start()
    {
        // Ensure all audio sources are assigned
        if (crowdAudioSource == null || leftSpeaker == null || rightSpeaker == null)
        {
            Debug.LogError("Please assign all AudioSources in the Inspector!");
            return;
        }

        if (crowdClip == null || bandClip == null)
        {
            Debug.LogError("Please assign all Audio Clips in the Inspector!");
            return;
        }

        // Stop all audio sources at the start
        //crowdAudioSource.Stop();
        //leftSpeaker.Stop();
        //rightSpeaker.Stop();

        // Assign clips and ensure proper configuration
        crowdAudioSource.clip = crowdClip;
        leftSpeaker.clip = bandClip;
        rightSpeaker.clip = bandClip;

        //leftSpeaker.loop = true;
        //rightSpeaker.loop = true;

        // Start the sequence with an initial delay
        Invoke(nameof(PlayCrowdSound), initialDelay);
    }

    void PlayCrowdSound()
    {
        // Play the crowd cheering sound effect
        crowdAudioSource.Play();
        Debug.Log("Crowd sound started at: " + AudioSettings.dspTime);

        // Schedule the band sound start time
        bandStartDspTime = AudioSettings.dspTime + bandStartDelay;
        Debug.Log("Band sound scheduled to start at: " + bandStartDspTime);

        // Start fading out the crowd sound
        StartCoroutine(FadeOutCrowd(crowdFadeDuration));

        // Start the band sound after the crowd fade duration
        //Invoke(nameof(PlayBandSound), bandStartDelay);
    }

    void PlayBandSound()
    {
        // Play the band audio clips on both speakers synchronously
        //leftSpeaker.PlayScheduled(bandStartDspTime);
        //rightSpeaker.PlayScheduled(bandStartDspTime);
        Debug.Log("Band sound started at: " + AudioSettings.dspTime);
    }

    System.Collections.IEnumerator FadeOutCrowd(float fadeDuration)
    {
        float startVolume = crowdAudioSource.volume;

        // Gradually reduce the volume over the fade duration
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            crowdAudioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        // Ensure the volume is set to 0 and stop the audio source
        crowdAudioSource.volume = 0;
        crowdAudioSource.Stop();
    }
}

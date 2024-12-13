using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Audio Sources
    public AudioSource crowdAudioSource;
    public AudioSource leftSpeaker;
    public AudioSource rightSpeaker;

    // Audio Clips
    public AudioClip crowdClip;
    public AudioClip bandClip;

    // Settings
    public float crowdFadeDuration = 5f;
    public float delayBeforeCrowd = 2.5f;
    public float bandStartDelay = 5f;

    private double songStartDspTime;
    private bool hasRestarted = false; // To prevent multiple reload attempts

    void Start()
    {
        // Ensure all necessary references are assigned
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

        // Assign the crowd clip and configure it
        crowdAudioSource.clip = crowdClip;
        crowdAudioSource.loop = false;

        // Assign the band clip to both speakers and configure them
        leftSpeaker.clip = bandClip;
        rightSpeaker.clip = bandClip;
        leftSpeaker.loop = true;
        rightSpeaker.loop = true;

        // **Stop the speakers immediately at the start**
        leftSpeaker.Stop();
        rightSpeaker.Stop();
        crowdAudioSource.Stop();

        // Log that the audio sources are stopped at the start
        Debug.Log("Audio sources stopped at the start.");

        // Get the DSP time at the start of the scene
        songStartDspTime = AudioSettings.dspTime;
        //Debug.Log("Song Start DSP Time: " + songStartDspTime);

        // Start the sequence (crowd sound first)
        //Invoke(nameof(PlayCrowdSound), delayBeforeCrowd);
    }

    public void PlayBandSound()
    {
        Debug.Log("Band sound started at " + AudioSettings.dspTime);
        leftSpeaker.Play();
        rightSpeaker.Play();

        StartCoroutine(CheckSongEnd());
    }

    private IEnumerator CheckSongEnd()
    {
        // Wait for both speakers to stop playing
        while (leftSpeaker.isPlaying || rightSpeaker.isPlaying)
        {
            yield return null; // Wait for the next frame
        }

        // Once the audio stops, restart the scene
        if (!hasRestarted)
        {
            hasRestarted = true; // Prevent multiple restarts
            RestartScene();
        }
    }

    private void RestartScene()
    {
        Debug.Log("Restarting scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

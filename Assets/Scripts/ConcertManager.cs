using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConcertManager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject withAudienceButton;  // Floating button for "With Audience"
    public GameObject withoutAudienceButton; // Floating button for "Without Audience"

    [Header("Audio Sources")]
    public AudioSource songAudioSource;    // The audio source for the song

    [Header("Delay Settings")]
    public float bandStartDelay = 2f;      // Delay before band starts playing

    [Header("Audience")]
    public GameObject audiencePrefab;      // Prefab to spawn audience members
    public Transform audienceSpawnPoint;   // Spawn point for the audience

    void Start()
    {
        // Ensure all necessary components are assigned
        if (songAudioSource == null)
        {
            Debug.LogError("Please assign the AudioSource for the song!");
            return;
        }

        // Silence the audio at start
        songAudioSource.Stop();

        // Set up button interactions
        SetUpButton(withAudienceButton, () => StartConcert(true));
        SetUpButton(withoutAudienceButton, () => StartConcert(false));
    }

    // Set up the button interactions
    private void SetUpButton(GameObject button, System.Action onPressAction)
    {
        if (button.TryGetComponent(out XRGrabInteractable interactable))
        {
            interactable.activated.AddListener((interaction) => onPressAction());
        }
        else
        {
            Debug.LogError($"Button {button.name} does not have XRGrabInteractable component!");
        }
    }

    // Triggered when either button is pressed
    private void StartConcert(bool withAudience)
    {
        Debug.Log(withAudience ? "Starting concert with audience!" : "Starting concert without audience!");

        // Spawn audience if the "With Audience" button was pressed
        if (withAudience && audiencePrefab != null && audienceSpawnPoint != null)
        {
            Instantiate(audiencePrefab, audienceSpawnPoint.position, audienceSpawnPoint.rotation);
        }

        // Start the band after a delay
        Invoke(nameof(StartBand), bandStartDelay);
    }

    // Starts the band by playing the audio
    private void StartBand()
    {
        songAudioSource.Play();
        Debug.Log("Band started playing!");
    }
}

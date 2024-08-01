using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioWhileKeyDown : MonoBehaviour
{
    public KeyCode key = KeyCode.W; // Key to trigger audio playback
    public AudioClip audioClip; // Audio clip to play
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the audio clip to play
        audioSource.clip = audioClip;

        // Ensure the audio clip loops continuously while the key is held down
        audioSource.loop = true;
    }

    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(key))
        {
            // Play the audio clip
            audioSource.Play();
        }
        // Check if the specified key is released
        else if (Input.GetKeyUp(key))
        {
            // Stop playing the audio clip
            audioSource.Stop();
        }
    }
}

using UnityEngine;
using FMODUnity;

public class MusicController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string musicEvent = "event:/padfolder/pad1";

    private FMOD.Studio.EventInstance musicEventInstance;
    private bool isPlaying = false;
    private float lastCollisionTime; // Added variable to store the time of the last collision

    void Start()
    {
        // Create an instance of the music event
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        musicEventInstance.setVolume(0.0f); // Set initial volume to 0
        musicEventInstance.start(); // Start playback
        musicEventInstance.release(); // Release the event instance (the track will continue playing)
        lastCollisionTime = -1f; // Initialize to a negative value to ensure the first collision is always considered
    }

    // Called on collision with another collider
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Time.time - lastCollisionTime >= 0.5f))
        {
            ToggleMusic(); // Handle collision with the game object
            lastCollisionTime = Time.time; // Update the time of the last collision
        }
    }

    void ToggleMusic()
    {
        if (!isPlaying)
        {
            musicEventInstance.setVolume(1.0f); // Increase volume to 1
            isPlaying = true;
        }
        else
        {
            musicEventInstance.setVolume(0.0f); // Decrease volume to 0
            isPlaying = false;
        }
    }
}



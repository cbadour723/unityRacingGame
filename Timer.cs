using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Public variable to hold the elapsed time
    public float elapsedTime { get; private set; }

    private float startTime;
    public RaceManager raceManager;

    private TMP_Text fastestTime;

    void Start()
    {
        // Record the start time when the game starts
        startTime = Time.time;

    }

    void Update()
    {
        // Calculate the elapsed time since the game started
        elapsedTime = Time.time - startTime;
        if (raceManager != null && raceManager.isRaceWon)
        {
            PlayerPrefs.SetFloat("HighScore", elapsedTime);
        }
    }

    // Save the fastest time to PlayerPrefs

}


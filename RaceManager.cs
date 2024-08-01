using System.Collections.Generic;
using UnityEngine;


public class RaceManager : MonoBehaviour
{
    public WaypointManager waypointManager;
    public Timer timer;
    public ScoreManager scoreManager;
    public string playerName;
    public bool isRaceWon = false;

    

    // Reference to the other cars participating in the race
    public List<Transform> otherCars;

    private Vector3 firstTrackWinningWaypoint = new Vector3(73.18f, 8.311563f, 126.9f);
    private Vector3 secondTrackWinningWaypoint = new Vector3(23.3999996f, 0, -2.29999995f);
    private bool isPaused = false;
    public Rigidbody rb;
    int[] lapcount = new int[2];
    int count = 0;
    int playerPosition = 1; // Initialize player's position to 1

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPaused = false;
        isRaceWon = false;
}

    void Update()
    {
        CheckWinCondition();
        UpdatePlayerPosition();
    }

    private void CheckWinCondition()
    {
        if (waypointManager.waypoints.Count > 0)
        {
            if (Vector3.Distance(rb.position, firstTrackWinningWaypoint) < 25f)
            {
                count++;
                if (count >= 3)
                {
                    WinRace(firstTrackWinningWaypoint);
                }

            }
            else if (Vector3.Distance(waypointManager.waypoints[0].position, secondTrackWinningWaypoint) < 0.1f)
            {
                WinRace(secondTrackWinningWaypoint);
            }
        }
    }

    private void WinRace(Vector3 winningWaypoint)
    {
        isRaceWon = true;
        PauseGame();
        float score = timer.elapsedTime;
        scoreManager.AddScore(new Score(playerName, score));
        Debug.Log(playerName + " wins the race with a score of " + score);
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    void UpdatePlayerPosition()
    {
        // Sort the cars based on their distance from the first track winning waypoint
        otherCars.Sort((a, b) =>
        {
            float distanceToA = Vector3.Distance(a.position, firstTrackWinningWaypoint);
            float distanceToB = Vector3.Distance(b.position, firstTrackWinningWaypoint);
            return distanceToA.CompareTo(distanceToB);
        });

        // Find the index of the player's car in the sorted list
        int playerIndex = otherCars.IndexOf(rb.transform);

        // Update player's position based on their index
        playerPosition = playerIndex + 1;
    }

    public int GetPlayerPosition()
    {
        return playerPosition;
    }
}


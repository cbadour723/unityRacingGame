using UnityEngine;
using UnityEngine.UI;

public class RaceResultUI : MonoBehaviour
{
    public RaceManager raceManager; // Reference to the RaceManager script
    public GameObject winPanel; // Reference to the panel for winning
    public GameObject losePanel; // Reference to the panel for losing
    public GameObject pauseMenuUi;


    void Start()
    {
        // Deactivate both panels at the start
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        pauseMenuUi.SetActive(false);
    }

    void Update()
    {
        // Check if the race has been won
        if (raceManager != null && raceManager.isRaceWon)
        {
            // Activate the win panel if the player won
            if (raceManager.GetPlayerPosition() == 1)
            {
                winPanel.SetActive(true);
            }
            else
            {
                // Activate the lose panel if the player didn't win
                losePanel.SetActive(true);
            }
            pauseMenuUi?.SetActive(true);
        }
    }
}

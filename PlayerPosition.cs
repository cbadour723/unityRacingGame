using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPositionUI : MonoBehaviour
{
    public RaceManager raceManager; // Reference to the RaceManager script
    private TMP_Text positionText; // Reference to the Text component

    void Start()
    {
        positionText = GetComponent<TMP_Text>(); // Get the Text component
    }

    void Update()
    {
        if (raceManager != null)
        {
            positionText.text = "Position: " + raceManager.GetPlayerPosition(); // Update the text with player's position
        }
    }
}
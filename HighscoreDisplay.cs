using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreDisplay : MonoBehaviour
{
    public Timer timer;
    private TMP_Text text; // Use TMP_Text instead of Text

    void Start()
    {
        text = GetComponent<TMP_Text>(); // Use GetComponent<TMP_Text>() to get the TextMeshPro component
    }

    void Update()
    {
        // Update the text to display the elapsed time
        if (PlayerPrefs.GetFloat("Highscore", timer.elapsedTime)  != 0)
        {

            text.text = "Fastest Time: " + PlayerPrefs.GetFloat("Highscore", timer.elapsedTime).ToString("F2");
        }
        else
        {
            text.text = "Timer component not assigned!";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Timer timer; // Reference to the Timer component

    private TMP_Text text; // Use TMP_Text instead of Text

    void Start()
    {
        text = GetComponent<TMP_Text>(); // Use GetComponent<TMP_Text>() to get the TextMeshPro component
    }

    void Update()
    {
        // Update the text to display the elapsed time
        if (timer != null)
        {
            text.text = "Time: " + timer.elapsedTime.ToString("F2");
        }
        else
        {
            text.text = "Timer component not assigned!";
        }
    }
}
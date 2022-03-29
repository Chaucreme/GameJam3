using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //---------------------- GLOBAL VARIABLES ----------------------
    float currentTime = 0f;
    float startingTime = 15f; // Time starts at 15 seconds and counts dwn

    // for text display in GUI canvas
    [SerializeField] Text countdownText;

    //---------------------------- START ----------------------------
    private void Start()
    {
        // Timer is changed from 0 to 10, starting at 10
        currentTime = startingTime;
    }

    //---------------------------- UPDATE ----------------------------
    void Update()
    {
        // This is what counts down the timer every update
        currentTime -= 1 * Time.deltaTime;

        // If...Else: fixes the format of 00:00 when the currentTime is less than 10
        if (currentTime < 10)
        {
            // Displays the countdown on screen using a UI canvas
            countdownText.text = "00:0" + currentTime.ToString("0"); // Add(+) another variable for minutes
        }
        else
        {
            countdownText.text = "00:" + currentTime.ToString("0"); // Add(+) another variable for minutes
        }

        // When the timer gets to Zero then set currentTime to 0, to stay and not go into the negatives
        if (currentTime <= 0)
        {
            // Add Code to End the Game GUI
            currentTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
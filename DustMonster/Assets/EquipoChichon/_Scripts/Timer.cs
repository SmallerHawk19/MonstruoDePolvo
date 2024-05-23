using TMPro;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 90;
    public bool isRunning = false;
    public TextMeshProUGUI reloj;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                UpdateTimerDisplay(timeRemaining);
            }
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        reloj.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
    }
}


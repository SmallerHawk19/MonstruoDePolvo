using TMPro;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeRemaining = 90;
    [SerializeField] private TextMeshProUGUI _timerText;

    private bool _isRunning = false;
    private float _initialTime;

    private void Start()
    {
        _initialTime = _timeRemaining;
        UpdateTimerDisplay(_timeRemaining);
    }

    private void Update()
    {
        if (_isRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(_timeRemaining);
            }
            else
            {
                _timeRemaining = 0;
                _isRunning = false;
                GameManager.Instance.TimerFinished();
                UpdateTimerDisplay(_timeRemaining);
            }
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        _timerText.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
    }

    public void AddTime(float time)
    {
        if (_isRunning)
        {
             _timeRemaining += time;
        }
    }

    public void TimmerRunning(bool running)
    {
        _isRunning = running;
    }

    public void ResetTimer()
    {
        _timeRemaining = _initialTime;
        UpdateTimerDisplay(_timeRemaining);
    }
}


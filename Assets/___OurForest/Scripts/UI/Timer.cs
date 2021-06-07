using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] FloatSO timeRemaining;
    [SerializeField] BoolSO timerIsRunning;
    [SerializeField] TMP_Text timeText;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining.value > 0)
            {
                timeRemaining.value -= Time.deltaTime;
                DisplayTime(timeRemaining.value);
            }
            else
            {
                timeRemaining.value = 0;
                timerIsRunning.state = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
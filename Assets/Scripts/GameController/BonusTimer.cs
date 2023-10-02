using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusTimer : MonoBehaviour
{
    public float timeLeft = 20;
    public bool isActive = false;

    public TextMeshProUGUI timerText;


    public void Setup(float startTime)
    {
        timeLeft = startTime;
        gameObject.SetActive(true);
        isActive = true;
    }


    void Update()
    {
        if (isActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                isActive = false;
            }
        }
    }

    private void UpdateTimer(float currentTime)
    {
        float seconds = Mathf.FloorToInt(currentTime % 60);

        if (seconds < 0f)
        {
            seconds = 0;
            gameObject.SetActive(false);
        }

        timerText.text = string.Format("{00}", seconds);
    }
}
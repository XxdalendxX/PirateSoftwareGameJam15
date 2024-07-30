using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] GameOverMenu gameOverMenu;
    [SerializeField] UIManager uiManager;
    [SerializeField, Tooltip("Time in seconds")] float TotalTime;
    float remainingTime;

    public bool isCountingDown = true;

    void Start()
    {
        remainingTime = TotalTime;
    }

    void Update()
    {
        if (isCountingDown)
        {
            if (remainingTime > 0)
                CountDownTimer();
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                gameOverMenu.OpenMenu();
                return;
            }

            int hours = Mathf.FloorToInt(remainingTime / 3600) % 24;
            int minutes = Mathf.FloorToInt(remainingTime / 60) % 60;
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            if (hours > 0)
                uiManager.UpdateTimer(hours, minutes, seconds);
            else
                uiManager.UpdateTimer(minutes, seconds);
        }
    }

    public void CountDownTimer()
    {
        remainingTime -= Time.deltaTime;
    }

    public float GetTimeRemaining() { return remainingTime; }
}

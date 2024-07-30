using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWinMenu : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] TimerSystem timerSystem;
    [SerializeField] MoneySystem moneySystem;
    [SerializeField] PlayerInteractionHandler interactionHandler;

    [Space()]

    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text moneyText;

    #region RATINGS
    [Space()]
    [Header("Ratings")]
    [SerializeField, Tooltip("In Seconds")] int perfectTime;
    [SerializeField] int perfectMoney;
    [SerializeField] Color perfectColour;

    [Space()]
    [SerializeField, Tooltip("In Seconds")] int goodTime;
    [SerializeField] int goodMoney;
    [SerializeField] Color goodColour;

    [Space()]
    [SerializeField, Tooltip("In Seconds")] int okayTime;
    [SerializeField] int okayMoney;
    [SerializeField] Color okayColour;

    [Space()]
    [SerializeField, Tooltip("In Seconds")] int badTime;
    [SerializeField] int badMoney;
    [SerializeField] Color badColour;

    [Space()]
    [SerializeField, Tooltip("In Seconds")] int horribleTime;
    [SerializeField] int horribleMoney;
    [SerializeField] Color horribleColour;
    #endregion

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        uiManager.ToggleUI();
        timerSystem.isCountingDown = false;
        interactionHandler.TogglePlayerInput();

        SetTimeText();
        SetMoneyText();
    }

    public void ExitToMenu()
    {
        //exit to menu
    }

    void SetTimeText()
    {
        float timeRemaining = timerSystem.GetTimeRemaining();

        int hours = Mathf.FloorToInt(timeRemaining / 3600) % 24;
        int minutes = Mathf.FloorToInt(timeRemaining / 60) % 60;
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        if (hours > 0)
        {
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
        else
        {
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (timeRemaining >= perfectTime)
            timeText.color = perfectColour;
        else if (timeRemaining < perfectTime && timeRemaining >= goodTime)
            timeText.color = goodColour;
        else if (timeRemaining < goodTime && timeRemaining >= okayTime)
            timeText.color = okayColour;
        else if (timeRemaining < okayTime && timeRemaining >= badTime)
            timeText.color = badColour;
        else if (timeRemaining < badTime)
            timeText.color = horribleColour;

    }

    void SetMoneyText()
    {
        int totalMoney = moneySystem.GetTotalMoney();

        moneyText.text = (totalMoney.ToString() + "$");

        if (totalMoney >= perfectMoney)
            moneyText.color = perfectColour;
        else if (totalMoney < perfectMoney && totalMoney >= goodMoney)
            moneyText.color = goodColour;
        else if (totalMoney < goodMoney && totalMoney >= okayMoney)
            moneyText.color = okayColour;
        else if (totalMoney < okayMoney && totalMoney >= badMoney)
            moneyText.color = badColour;
        else if (totalMoney < badMoney)
            moneyText.color = horribleColour;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] TimerSystem timerSystem;
    [SerializeField] PlayerInteractionHandler interactionHandler;

    [Space]

    [SerializeField] Canvas areYouSureMenu;
    [SerializeField] TMPro.TMP_Text timeLeftText;

    private void Update()
    {
        bool isActive = gameObject.activeSelf;
        bool confirmationTextActive = areYouSureMenu.gameObject.activeSelf;

        if (isActive)
        {
            if (confirmationTextActive && Input.GetKeyDown(KeyCode.Escape))
                YouAreNotLeaving();
            else if (Input.GetKeyDown(KeyCode.Escape))
                Resume();
        }  
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);

        uiManager.ToggleUI();

        timerSystem.isCountingDown = false;

        interactionHandler.TogglePlayerInput();

        Vector3 time = GetTime();
        if (time.z > 0)
        {
            timeLeftText.SetText("You Have " + (string.Format("{0:00}:{1:00}:{2:00}", time.z, time.y, time.x)) + " remaining");
        }
        else
        {
            timeLeftText.SetText($"You Have " + (string.Format("{0:00}:{1:00}", time.y, time.x)) + " remaining");
        }
    }

    public void Resume()
    {
        uiManager.ToggleUI();

        timerSystem.isCountingDown = true;

        interactionHandler.TogglePlayerInput();

        gameObject.SetActive(false);
    }

    public void Leave()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        areYouSureMenu.transform.gameObject.SetActive(true);
    }

    public void YouAreLeaving()
    {
        SceneManager.LoadScene(0);
    }

    public void YouAreNotLeaving()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        areYouSureMenu.transform.gameObject.SetActive(false);
    }

    Vector3 GetTime()
    {
        float remainingTime = timerSystem.GetTimeRemaining();

        int hours = Mathf.FloorToInt(remainingTime / 3600) % 24;
        int minutes = Mathf.FloorToInt(remainingTime / 60) % 60;
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        return new Vector3(seconds, minutes, hours);
    }
}

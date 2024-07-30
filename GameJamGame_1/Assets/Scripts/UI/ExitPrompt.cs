using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPrompt : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerInteractionHandler interactionHandler;
    [SerializeField] TimerSystem timerSystem;
    [SerializeField] GameWinMenu gameWinMenu;

    public void Stay()
    {
        gameObject.SetActive(false);

        uiManager.ToggleUI();

        timerSystem.isCountingDown = true;

        interactionHandler.TogglePlayerInput();
    }

    public void Leave()
    {
        Debug.Log("You're leaving now good job");
        gameWinMenu.OpenMenu();
        gameObject.SetActive(false);
    }







}

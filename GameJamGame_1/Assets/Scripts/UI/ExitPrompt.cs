using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPrompt : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerInteractionHandler interactionHandler;
    [SerializeField] TimerSystem timerSystem;

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
        //exit to main menu or summary canvas or whatever
    }







}

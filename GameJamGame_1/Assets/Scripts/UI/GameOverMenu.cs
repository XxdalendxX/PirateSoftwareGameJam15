using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] TimerSystem timerSystem;
    [SerializeField] PlayerInteractionHandler interactionHandler;

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        uiManager.ToggleUI();
        timerSystem.isCountingDown = false;
        interactionHandler.TogglePlayerInput();
    }

    public void ExitToMenu()
    {
        //exit to menu
    }
}

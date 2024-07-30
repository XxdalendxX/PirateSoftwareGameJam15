using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(0);
    }
}

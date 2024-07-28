using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPrompt : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerInteractionHandler interactionHandler;

    public void Stay()
    {
        gameObject.SetActive(false);

        uiManager.ToggleUI();

        //start Timer again

        interactionHandler.TogglePlayerInput();
    }

    public void Leave()
    {
        Debug.Log("You're leaving now good job");
        //exit to main menu or summary canvas or whatever
    }







}

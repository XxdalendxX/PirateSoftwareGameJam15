using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Van : Interactible
{
    [Space(5)]
    [Header("Van Values")]

    [SerializeField] UIManager uIManager;
    [SerializeField] WeightSystem weightSystem;
    [SerializeField] ExitPrompt exitPrompt;


    public override void InteractionAction()
    {
        weightSystem.ClearWeight();
    }

    public override void SecondaryInteractionAction()
    {
        uIManager.ToggleUI();

        //Make Timer Stop

        interactionHandler.TogglePlayerInput();

        exitPrompt.gameObject.SetActive(true);
    }
}

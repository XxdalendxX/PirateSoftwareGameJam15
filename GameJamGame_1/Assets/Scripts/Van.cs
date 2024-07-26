using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Van : Interactible
{
    [Space(5)]
    [Header("Van Values")]

    [SerializeField] UIManager uIManager;

    [SerializeField] ExitPrompt exitPrompt;
   public override void InteractionAction()
    {
        Debug.Log("LF likes licking feet");
        uIManager.ToggleUI();

        //Make Timer Stop

        //Prevent Player Movement / interaction
        
        exitPrompt.gameObject.SetActive(true);
    }
}

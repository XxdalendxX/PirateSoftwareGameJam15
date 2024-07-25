using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Van : Interactible
{
    [SerializeField] ExitPrompt exitPrompt;
   public override void InteractionAction()
    {
        Debug.Log("LF likes licking feet");

        //Make Timer Stop

        //Prevent Player Movement / interaction
        
        //turn on ExitPrompt
        exitPrompt.gameObject.SetActive(true);
    }
}

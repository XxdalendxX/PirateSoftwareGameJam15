using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [HideInInspector] public bool isInteracting = false;
    [HideInInspector] public Interactible interactingObject;

    public void EnterInteraction(Interactible object_)
    {
        interactingObject = object_;
        isInteracting = true;
    }

    public void ExitInteraction()
    {
        isInteracting = false;
        interactingObject = null;
    }

    public void PlayerIsInteracting()
    {
        interactingObject.InteractionAction();
    }

    public void DeleteObject()
    {
        
    }

}

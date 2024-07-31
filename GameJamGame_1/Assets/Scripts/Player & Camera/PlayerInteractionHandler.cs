using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [HideInInspector] public bool isInteracting = false;
    [HideInInspector] public Interactible interactingObject;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canInteract = true;
    [HideInInspector] public bool pausing = false;

    [SerializeField] PauseMenuScript pauseMenu;
    [SerializeField] Transform fullPromptObject;
    [SerializeField] float fullPromptDisplayTime;

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

    public void PlayerIsDoingTheOtherInteraction()
    {
        interactingObject.SecondaryInteractionAction();
    }

    public void DeletePickupObject(GameObject objectToDelete)
    {
        Object.Destroy(objectToDelete);
    }

    public void TogglePlayerInput()
    {
        if (canMove)
            canMove = false;
        else
            canMove = true;
    }

    public void PauseTheGame()
    {
        pauseMenu.OpenMenu();
    }

    public IEnumerator DisplayFullText()
    {
        fullPromptObject.gameObject.SetActive(true);
        canInteract = false;

        yield return new WaitForSeconds(fullPromptDisplayTime);

        canInteract = true;
        fullPromptObject.gameObject.SetActive(false);
    }

}

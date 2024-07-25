using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] GameObject interactionPrompt;
    Transform interactionPromptObject;
    PlayerInteractionHandler interactionHandler;

    #region TriggerInteraction
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if(collidingObject.gameObject.tag == "Player")
        {
            interactionHandler = collidingObject.GetComponent<PlayerInteractionHandler>();

            if (!interactionHandler.isInteracting)
            {
                interactionPromptObject = Instantiate(interactionPrompt).transform;
                interactionPromptObject.position = new Vector3(transform.position.x, interactionHandler.transform.position.y, transform.position.z);
                interactionHandler = collidingObject.GetComponent<PlayerInteractionHandler>();
                interactionHandler.EnterInteraction(this);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.tag == "Player")
        {
            interactionHandler = collidingObject.GetComponent<PlayerInteractionHandler>();

            if (!interactionHandler.isInteracting)
            {
                interactionPromptObject = Instantiate(interactionPrompt).transform;
                interactionPromptObject.position = new Vector3(transform.position.x, interactionHandler.transform.position.y, transform.position.z);
                interactionHandler = collidingObject.GetComponent<PlayerInteractionHandler>();
                interactionHandler.EnterInteraction(this);
            }
            interactionHandler = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.tag == "Player" && interactionPromptObject != null)
        {
            interactionHandler = collidingObject.GetComponent<PlayerInteractionHandler>();

            interactionHandler.ExitInteraction();
            Object.Destroy(interactionPromptObject.gameObject);
        }
            
    }
    #endregion

    public virtual void InteractionAction() {}
}

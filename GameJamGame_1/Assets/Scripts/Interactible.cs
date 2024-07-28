using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] GameObject interactionPrompt;
    Transform interactionPromptObject;
    protected PlayerInteractionHandler interactionHandler;

    #region TriggerInteraction
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if(collidingObject.gameObject.tag == "Player")
        {
            interactionHandler = collidingObject.GetComponent<PlayerInteractionHandler>();

            if (!interactionHandler.isInteracting)
            {
                PlayerIsInteracting(collidingObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.tag == "Player")
        {
            if (!interactionHandler.isInteracting)
            {
                PlayerIsInteracting(collidingObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.tag == "Player")
        {
            interactionHandler.ExitInteraction();
            interactionHandler = null;

            Object.Destroy(transform.GetChild(0).gameObject);
        }
    }
    #endregion

    private void Update()
    {
        if (interactionHandler == null && transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public virtual void InteractionAction() {}

    public virtual void SecondaryInteractionAction() {}

    private void PlayerIsInteracting(Collider2D collidingObject)
    {
        interactionPromptObject = Instantiate(interactionPrompt).transform;
        interactionPromptObject.position = new Vector3(transform.position.x, interactionHandler.transform.position.y, transform.position.z - 0.01f);
        interactionPromptObject.parent = transform;

        interactionHandler = collidingObject.GetComponent<PlayerInteractionHandler>();
        interactionHandler.EnterInteraction(this);
    }
}

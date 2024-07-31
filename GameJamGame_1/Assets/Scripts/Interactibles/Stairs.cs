using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Interactible
{
    public Transform ExitStairs;

    public override void InteractionAction()
    {
        interactionHandler.transform.position = ExitStairs.position;
    }
}

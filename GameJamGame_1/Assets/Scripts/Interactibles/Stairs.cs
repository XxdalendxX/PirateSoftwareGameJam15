using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Interactible
{
    public Transform ExitStairs;

    public override void InteractionAction()
    {
        interactionHandler.transform.position = new Vector3(ExitStairs.position.x, ExitStairs.position.y, ExitStairs.position.z -1.5f);
    }
}

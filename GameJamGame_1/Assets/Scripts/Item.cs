using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactible
{
    [Space(20)]

    [SerializeField] float moneyValue;
    [SerializeField] float weight;

    public override void InteractionAction()
    {
        Debug.Log("Sikky is a motherfucking WOMPOM");
    }
}

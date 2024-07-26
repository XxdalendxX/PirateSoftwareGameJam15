using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactible
{
    [Space(5)]
    [Header("Item Values")]

    [SerializeField] int moneyValue;
    [SerializeField] float weight;

    WeightSystem weightSystem;
    MoneySystem moneySystem;

    private void Start()
    {
        weightSystem = GameObject.Find("GameManager").GetComponent<WeightSystem>();
        moneySystem = GameObject.Find("GameManager").GetComponent<MoneySystem>();
    }

    public override void InteractionAction()
    {
        Debug.Log("Sikky is a motherfucking WOMPOM");

        //increase weight

        moneySystem.IncreaseCurrency(moneyValue);

        interactionHandler.DeletePickupObject(gameObject);
    }
}

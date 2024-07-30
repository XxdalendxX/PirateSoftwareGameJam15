using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    
    int currencyTotal = 0;

    public void IncreaseCurrency(int itemPrice) => uiManager.UpdateMoney(currencyTotal += itemPrice);

    public int GetTotalMoney() { return currencyTotal; }
}

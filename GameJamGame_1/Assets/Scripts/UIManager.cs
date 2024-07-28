using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text weightText;
    [SerializeField] TMP_Text timeText;

    [Space(50)]

    [SerializeField] Transform moneyUI;
    [SerializeField] Transform weightUI;
    [SerializeField] Transform timeUI;

    [Header("Weight Colours")]
    [SerializeField] Color lightWeightColour;
    [SerializeField] Color moderateWeightColour;
    [SerializeField] Color heavyWeightColour;
    [SerializeField] Color encumberedWeightColour;

    

    public void UpdateMoney(int totalMoney) =>
        moneyText.text = totalMoney.ToString();

    public void UpdateWeight(float totalWeight, WeightLevel weightLevel)
    {
        weightText.text = totalWeight.ToString();

        switch(weightLevel)
        {
            case WeightLevel.Light:
                weightText.color = lightWeightColour;
                break;
            case WeightLevel.Moderate:
                weightText.color = moderateWeightColour;
                break;
            case WeightLevel.Heavy:
                weightText.color = heavyWeightColour;
                break;
            case WeightLevel.Encumbered:
                weightText.color = encumberedWeightColour;
                break;
        }
    }

    public void ToggleUI()
    {
        if (moneyUI != null) //Toggle moneyUI
            moneyUI.gameObject.SetActive(!moneyUI.gameObject.activeSelf);
        if (weightUI != null) //Toggle weightUI
            weightUI.gameObject.SetActive(!weightUI.gameObject.activeSelf);
        if (timeUI != null) //Toggle TimeUI
            timeUI.gameObject.SetActive(!timeUI.gameObject.activeSelf);
    }
}

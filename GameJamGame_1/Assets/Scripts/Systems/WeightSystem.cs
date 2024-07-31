using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeightLevel
{
    Light,
    Moderate,
    Heavy,
    Encumbered
}

public class WeightSystem : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerInfo playerInfo;

    float totalWeight;
    WeightLevel weightLevel;

    [Header("Weight Threshholds")]
    [SerializeField] int moderateWeightThreshhold;
    [SerializeField] int heavyWeightThreshhold;
    [SerializeField] int encumberedWeightThreshhold;

    [Header("PlayerSpeedsPerWeightClass")]
    [SerializeField] float lightSpeed;
    [SerializeField] float moderateSpeed;
    [SerializeField] float heavySpeed;
    [SerializeField] float encumberedSpeed;

    private void Start()
    {
        weightLevel = WeightLevel.Light;
        totalWeight = playerInfo.playerWeight;
        playerInfo.playerSpeed = lightSpeed;

        uiManager.UpdateWeight(totalWeight, weightLevel);
    }

    public void IncreaseWeight(float weightToAdd)
    {
        totalWeight += weightToAdd;

        WeightLevel oldWeightLevel = weightLevel;

        if (totalWeight >= encumberedWeightThreshhold)
            weightLevel = WeightLevel.Encumbered;
        else if (totalWeight >= heavyWeightThreshhold)
            weightLevel = WeightLevel.Heavy;
        else if (totalWeight >= moderateWeightThreshhold)
            weightLevel = WeightLevel.Moderate;

        if (oldWeightLevel != weightLevel)
        {
            switch(weightLevel)
            {
                case WeightLevel.Light:
                    playerInfo.playerSpeed = lightSpeed;
                    break;
                case WeightLevel.Moderate:
                    playerInfo.playerSpeed = moderateSpeed;
                    break;
                case WeightLevel.Heavy:
                    playerInfo.playerSpeed = heavySpeed;
                    break;
                case WeightLevel.Encumbered:
                    playerInfo.playerSpeed = encumberedSpeed;
                    break;

            }
        }

        uiManager.UpdateWeight(totalWeight, weightLevel);
    }

    public void ClearWeight()
    {
        totalWeight = playerInfo.playerWeight;
        weightLevel = WeightLevel.Light;
        playerInfo.playerSpeed = lightSpeed;

        uiManager.UpdateWeight(totalWeight, weightLevel);
    }

    public bool CanCarry(float itemWeight)
    {
        if (totalWeight + itemWeight > playerInfo.maxWeight)
            return false;
        else
            return true;
    }
}

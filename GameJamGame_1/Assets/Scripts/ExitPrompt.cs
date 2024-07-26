using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPrompt : MonoBehaviour
{
    [SerializeField] UIManager uiManager;

    public void Stay()
    {
        gameObject.SetActive(false);

        uiManager.ToggleUI();

        //start Timer again

        //allow player movement / interactions
    }

    public void Leave()
    {
        Debug.Log("You're leaving now good job");
        //exit to main menu or summary canvas or whatever
    }







}

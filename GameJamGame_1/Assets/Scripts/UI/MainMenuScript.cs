using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Transform controlsText;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        controlsText.gameObject.SetActive(!controlsText.gameObject.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject controlsUI;
    public GameObject mainMenuUI;

    public void BackButton()
    {
        if(SceneManager.GetActiveScene().name == "Grace Test")
        {
            controlsUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            controlsUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
    }
}

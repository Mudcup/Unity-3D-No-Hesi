using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsUI;
    public GameObject mainMenuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene("Grace Test");
        //SceneManager.LoadScene(SceneManager.GetActiveScreen().buildIndex + 1); //Good for Scene Progression
    }
    public void Controls()
    {
        mainMenuUI.SetActive(false);
        controlsUI.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}

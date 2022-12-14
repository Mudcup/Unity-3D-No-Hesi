using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Reference Video: https://www.youtube.com/watch?v=JivuXdrIHK0

public class PauseMenu : MonoBehaviour
{
    public static bool pausedGame = false;

    public GameObject pauseMenuUI;
    public GameObject controlsUI;
    AudioSource mainCamera;
    AudioSource car;

    [SerializeField] private Slider volumeSlider = null;
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeValue");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        car = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pausedGame = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pausedGame = true;
    }

    public void LoadControls()
    {
        controlsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    public void AdjustVolume(float volume)
    {
        mainCamera.volume = (float)0.8 * volume;
        car.volume = (float)0.6 * volume;
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    public static bool pausedGame = true;
    public GameObject TutorialUI;
    public GameObject SpeedometerUI;
    public GameObject LivesUI;
    public GameObject ScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        TutorialUI.SetActive(true);
        SpeedometerUI.SetActive(false);
        LivesUI.SetActive(false);
        ScoreUI.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        TutorialUI.SetActive(false);
        SpeedometerUI.SetActive(true);
        LivesUI.SetActive(true);
        ScoreUI.SetActive(true);
    }
}

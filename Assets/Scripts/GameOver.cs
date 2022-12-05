using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI score;

    public void Awake()
    {
        score = this.GetComponent<TextMeshProUGUI>();
        score.text = "SCORE: " + GameManager.finalScore;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Grace Test");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}

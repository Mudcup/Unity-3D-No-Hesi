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
        GameManager.lastRoadPositionZ = -100;
        GameManager.backRoadPositionZ = -100;
        GameManager.maxCollisions = 5;
        GameManager.currCollisions = 0;
        GameManager.finalScore = "";
        SceneManager.LoadScene("Grace Test");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}

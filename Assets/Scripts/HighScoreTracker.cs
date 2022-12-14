using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    void Start()
    {
        highScore = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = GameManager.highScore.ToString("0.00");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedTracker : MonoBehaviour
{
    public TextMeshProUGUI speedometer;
    public Rigidbody player;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speedometer = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        speedometer.text = player.velocity.z.ToString("0");
    }
}

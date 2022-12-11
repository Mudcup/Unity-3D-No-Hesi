using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    Rigidbody RB;
    public AudioSource EngineSource;
    public float PitchBoost;
    public float PitchRange;

    float Temp1;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        EngineSource.volume = 0.5f;
        EngineSource.pitch = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        float Speed = RB.velocity.magnitude;
        Temp1 = (Speed - ((int)Speed % 10) * 3) / 55;
        EngineSource.pitch = Mathf.Lerp(EngineSource.pitch, (PitchRange * Temp1) * PitchBoost, 0.01f);
    }
}

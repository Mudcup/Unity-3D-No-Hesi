using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        EngineSource.pitch = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        float Speed = RB.velocity.magnitude;
        int var = (int)Speed / 15;
        Temp1 = Mathf.Abs((Speed - (var * (2+var))) / 55);
        EngineSource.pitch = Mathf.Lerp(EngineSource.pitch, ((PitchRange * Temp1) * PitchBoost) + .25f, 0.01f);
    }
}

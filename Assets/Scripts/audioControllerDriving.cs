using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControllerDriving : MonoBehaviour
{
    AudioClip loop;
    AudioSource mainCamera;
    private void Start()
    {
        loop = (AudioClip)Resources.Load("Audio_Assets/driving_loop_2");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        StartCoroutine(manageAudio());
    }

    IEnumerator manageAudio()
    {
        mainCamera.enabled = true;
        yield return new WaitForSecondsRealtime(mainCamera.clip.length);
        mainCamera.clip = loop;
        mainCamera.enabled = false;
        mainCamera.enabled = true;
    }
}

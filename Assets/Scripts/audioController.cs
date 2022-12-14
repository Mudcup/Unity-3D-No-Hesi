using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    AudioClip loop;
    AudioSource mainCamera;
    private void Start()
    {
        loop = (AudioClip)Resources.Load("Audio_Assets/menu_loop_2");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        StartCoroutine(manageAudio());
    }

    IEnumerator manageAudio()
    {
        yield return new WaitForSecondsRealtime(mainCamera.clip.length);
        mainCamera.clip = loop;
        mainCamera.enabled = false;
        mainCamera.enabled = true;
    }
}

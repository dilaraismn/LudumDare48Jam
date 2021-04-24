using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (Input.GetKeyDown("2"))
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
        if (Input.GetKeyDown("3"))
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }
    }
}

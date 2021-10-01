using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySound(AudioClip clip, AudioSource audioSource)
    {
        if (clip && audioSource)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

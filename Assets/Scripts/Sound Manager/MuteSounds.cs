using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSounds : MonoBehaviour
{
    private bool soundMuted = false;

    public void ToggleSound()
    {
        soundMuted = !soundMuted;

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = soundMuted;
        }
    }
}

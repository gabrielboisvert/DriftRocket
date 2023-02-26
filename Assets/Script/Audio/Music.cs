using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Music : MonoBehaviour
{
    public void Start()
    {
        GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
    }
}
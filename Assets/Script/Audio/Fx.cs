using System.Collections;
using UnityEngine;
public class Fx : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("Fx", PlayerPrefs.GetFloat("Fx"));
    }
    public IEnumerator DeleteSoundObj()
    {
        AudioSource src = GetComponent<AudioSource>();
        while (src.isPlaying)
            yield return null;
        Destroy(this.gameObject);
    }
    internal void OnFinish()
    {
        StartCoroutine(this.DeleteSoundObj());
    }
}
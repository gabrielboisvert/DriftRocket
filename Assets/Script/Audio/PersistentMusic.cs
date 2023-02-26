using UnityEngine;
public class PersistentMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public void Start()
    {
        if (GameManager.MainMenuMusic == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            this.audioSource = GetComponent<AudioSource>();
            GameManager.MainMenuMusic = this;
            GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
            GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("Fx", PlayerPrefs.GetFloat("Fx"));

            this.audioSource.Play();
        }
        else
        {
            Destroy(this.gameObject);
            GameManager.MainMenuMusic.PlayMusic();
        }
            
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) 
            return;
        
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
}
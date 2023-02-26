using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuOptions : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.InputActions.UIScrollStatic.startButton.started += this.OnBack;
    }
    private void OnDisable()
    {
        InputManager.InputActions.UIScrollStatic.startButton.started -= this.OnBack;
    }
    public void OnReset()
    {
        Time.timeScale = 1;
        GameManager.Fade.FadeStart(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnOptions(GameObject menu)
    {
        GameManager.PlaySound(this.GetComponent<AudioSource>().clip, GetComponent<AudioSource>().outputAudioMixerGroup);
        this.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
    public void OnMainMenu()
    {
        Time.timeScale = 1;
        GameManager.Fade.FadeStart("LevelSelector");
    }
    public void OnBack()
    {
        Time.timeScale = 1;
        GameManager.PlaySound(this.GetComponent<AudioSource>().clip, GetComponent<AudioSource>().outputAudioMixerGroup);
        this.gameObject.SetActive(false);

        InputManager.ToggleActionMap(InputManager.InputActions.Player);
        DSController.Controller.ResumeHaptics();
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        this.OnBack();
    }
}
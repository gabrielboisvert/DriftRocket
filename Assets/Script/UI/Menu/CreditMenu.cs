using UnityEngine;
using UnityEngine.Audio;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private AudioClip selecMove;
    private void OnEnable()
    {
        InputManager.InputActions.UIScrollStatic.Back.started += this.OnBack;

        InputManager.ToggleActionMap(InputManager.InputActions.UIScrollStatic);
    }
    private void OnDisable()
    {
        InputManager.InputActions.UIScrollStatic.Back.started -= this.OnBack;
    }
    private void OnBack(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        GameManager.PlaySound(this.selecMove, this.mixer);
        GameManager.Fade.FadeStart("HomeMenu");
    }
}

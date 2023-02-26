using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject oldMenu;
    [SerializeField] private GameObject buttons;
    [SerializeField] private Color selectedColor;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioClip selecMove;
    private GameObject selectedObj;
    private AudioSource src;
    int idx = 0;
    private void OnEnable()
    {
        InputManager.InputActions.UIScrollAllSide.downScroll.started += this.ScrollDown;
        InputManager.InputActions.UIScrollAllSide.upScroll.started += this.ScrollUp;
        InputManager.InputActions.UIScrollAllSide.rightScroll.started += this.ScrollRight;
        InputManager.InputActions.UIScrollAllSide.leftScroll.started += this.ScrollLeft;
        InputManager.InputActions.UIScrollAllSide.Select.started += this.OnBack;
        InputManager.InputActions.UIScrollAllSide.Back.started += this.OnBack;

        InputManager.ToggleActionMap(InputManager.InputActions.UIScrollAllSide);
    }
    private void OnDisable()
    {
        InputManager.InputActions.UIScrollAllSide.downScroll.started -= this.ScrollDown;
        InputManager.InputActions.UIScrollAllSide.upScroll.started -= this.ScrollUp;
        InputManager.InputActions.UIScrollAllSide.rightScroll.started -= this.ScrollRight;
        InputManager.InputActions.UIScrollAllSide.leftScroll.started -= this.ScrollLeft;
        InputManager.InputActions.UIScrollAllSide.Select.started -= this.OnBack;
        InputManager.InputActions.UIScrollAllSide.Back.started -= this.OnBack;
    }
    public void Start()
    {
        this.src = GetComponent<AudioSource>();

        this.buttons.transform.GetChild(0).GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music");
        this.buttons.transform.GetChild(1).GetComponent<Slider>().value = PlayerPrefs.GetFloat("Fx");

        this.selectedObj = this.buttons.transform.GetChild(this.idx).gameObject;
        this.ChangeColor();
    }
    public void OnBack()
    {
        GameManager.PlaySound(this.selecMove, this.src.outputAudioMixerGroup);
        PlayerPrefs.SetFloat("Music", this.buttons.transform.GetChild(0).GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("Fx", this.buttons.transform.GetChild(1).GetComponent<Slider>().value);

        this.gameObject.SetActive(false);
        if (this.oldMenu != null)
            this.oldMenu.SetActive(true);

        InputManager.ToggleActionMap(InputManager.InputActions.UIScrollStatic);
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        this.src.PlayOneShot(this.selecMove);
        AudioSource.PlayClipAtPoint(this.selecMove, new Vector3(0, 0, 0), 1);
        this.OnBack();
    }

    private void ScrollLeft(InputAction.CallbackContext obj)
    {
        this.selectedObj.GetComponent<Slider>().value -= 10;
        this.src.PlayOneShot(this.selecMove);
    }

    private void ScrollRight(InputAction.CallbackContext obj)
    {
        this.selectedObj.GetComponent<Slider>().value += 10;
        this.src.PlayOneShot(this.selecMove);
    }

    private void ScrollUp(InputAction.CallbackContext obj)
    {
        if (idx == this.buttons.transform.childCount - 1)
            idx = -1;

        this.ClearColor();
        this.selectedObj = this.buttons.transform.GetChild(++this.idx).gameObject;
        this.ChangeColor();
        this.src.PlayOneShot(this.selecMove);
    }

    private void ScrollDown(InputAction.CallbackContext obj)
    {
        if (idx == 0)
            idx = this.buttons.transform.childCount;

        this.ClearColor();
        this.selectedObj = this.buttons.transform.GetChild(--this.idx).gameObject;
        this.ChangeColor();
        this.src.PlayOneShot(this.selecMove);
    }
    private void ClearColor()
    {
        this.selectedObj.GetComponent<Slider>().handleRect.gameObject.GetComponent<Image>().color = Color.white;
        this.selectedObj.GetComponent<Slider>().fillRect.gameObject.GetComponent<Image>().color = Color.white;
    }
    private void ChangeColor()
    {
        this.selectedObj.GetComponent<Slider>().handleRect.gameObject.GetComponent<Image>().color = this.selectedColor;
        this.selectedObj.GetComponent<Slider>().fillRect.gameObject.GetComponent<Image>().color = this.selectedColor;
    }
    public void OnValueChange(string valueName)
    {
        if (this.selectedObj != null)
            this.mixer.SetFloat(valueName, this.selectedObj.GetComponent<Slider>().value);
    }
}
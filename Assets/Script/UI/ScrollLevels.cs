using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScrollLevels : MonoBehaviour
{
    [SerializeField] private Color selected = Color.white;
    [SerializeField] private UnityEvent eventOnBack = null;
    [SerializeField] private int levelWidth = 4;
    [SerializeField] private int levelHeight = 3;
    private GameObject cursor;
    private int xIdx = 0;
    private int yIdx = 0;
    [SerializeField] private GameObject laval;
    [SerializeField] private float lavaSpeed = 10;
    [SerializeField] private AudioClip selecMove;
    private AudioSource src;
    private bool hasClick = false;
    private void OnEnable()
    {
        InputManager.InputActions.UIScrollAllSide.downScroll.started += this.ScrollDown;
        InputManager.InputActions.UIScrollAllSide.upScroll.started += this.ScrollUp;
        InputManager.InputActions.UIScrollAllSide.rightScroll.started += this.ScrollRight;
        InputManager.InputActions.UIScrollAllSide.leftScroll.started += this.ScrollLeft;
        InputManager.InputActions.UIScrollAllSide.Select.started += this.OnAction;
        InputManager.InputActions.UIScrollAllSide.Back.started += this.OnBack;

        InputManager.ToggleActionMap(InputManager.InputActions.UIScrollAllSide);
    }
    private void OnDisable()
    {
        InputManager.InputActions.UIScrollAllSide.downScroll.started -= this.ScrollDown;
        InputManager.InputActions.UIScrollAllSide.upScroll.started -= this.ScrollUp;
        InputManager.InputActions.UIScrollAllSide.rightScroll.started -= this.ScrollRight;
        InputManager.InputActions.UIScrollAllSide.leftScroll.started -= this.ScrollLeft;
        InputManager.InputActions.UIScrollAllSide.Select.started -= this.OnAction;
        InputManager.InputActions.UIScrollAllSide.Back.started -= this.OnBack;
    }
    void Start()
    {
        this.cursor = this.transform.GetChild(this.levelWidth * this.yIdx + this.xIdx).gameObject;
        this.cursor.GetComponent<Image>().color = this.selected;
        this.src = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (this.hasClick)
            this.laval.transform.Translate(Vector3.forward * Time.deltaTime * this.lavaSpeed);
    }
    private void OnBack(InputAction.CallbackContext obj)
    {
        this.src.PlayOneShot(this.selecMove);
        this.eventOnBack?.Invoke();
    }

    private void OnAction(InputAction.CallbackContext obj)
    {
        this.hasClick = true;
        this.src.PlayOneShot(this.selecMove);
        this.laval.GetComponent<AudioSource>().Play();
        this.cursor.GetComponent<Button>().onClick.Invoke();
    }
    private void ScrollLeft(InputAction.CallbackContext obj)
    {
        if (this.xIdx == 0)
            this.xIdx = this.levelWidth;

        int idx = this.levelWidth * this.yIdx + --this.xIdx;

        this.cursor.GetComponent<Image>().color = Color.white;
        this.cursor = this.transform.GetChild(idx).gameObject;
        this.cursor.GetComponent<Image>().color = this.selected;
        this.src.PlayOneShot(this.selecMove);
    }
    private void ScrollRight(InputAction.CallbackContext obj)
    {
        if (this.xIdx == this.levelWidth - 1)
            this.xIdx = -1;

        int idx = this.levelWidth * this.yIdx + ++this.xIdx;

        this.cursor.GetComponent<Image>().color = Color.white;
        this.cursor = this.transform.GetChild(idx).gameObject;
        this.cursor.GetComponent<Image>().color = this.selected;
        this.src.PlayOneShot(this.selecMove);
    }

    private void ScrollUp(InputAction.CallbackContext obj)
    {
        if (this.levelHeight == 0)
            return;

        if (this.yIdx == 0)
            this.yIdx = levelHeight;

        int idx = this.levelWidth * --this.yIdx + this.xIdx;

        this.cursor.GetComponent<Image>().color = Color.white;
        this.cursor = this.transform.GetChild(idx).gameObject;
        this.cursor.GetComponent<Image>().color = this.selected;
        this.src.PlayOneShot(this.selecMove);
    }

    private void ScrollDown(InputAction.CallbackContext obj)
    {
        if (this.levelHeight == 0)
            return;

        if (this.yIdx == this.levelHeight - 1)
            this.yIdx = -1;

        int idx = this.levelWidth * ++this.yIdx + this.xIdx;

        this.cursor.GetComponent<Image>().color = Color.white;
        this.cursor = this.transform.GetChild(idx).gameObject;
        this.cursor.GetComponent<Image>().color = this.selected;
        this.src.PlayOneShot(this.selecMove);
    }
    public void BackMenu()
    {
        GameManager.Fade.FadeStart("HomeMenu");
    }
}
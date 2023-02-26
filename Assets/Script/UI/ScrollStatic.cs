using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScrollStatic : MonoBehaviour
{
    [SerializeField] private Color selected = Color.white;
    [SerializeField] private UnityEvent eventOnBack = null;
    [SerializeField] private Vector3 scale = Vector3.one;
    [SerializeField] private AudioClip selecMove;
    private AudioSource src;

    private GameObject cursor;
    private int childIdx = 0;
    private void OnEnable()
    {
        InputManager.InputActions.UIScrollStatic.downScroll.started += this.ScrollDown;
        InputManager.InputActions.UIScrollStatic.upScroll.started += this.ScrollUp;
        InputManager.InputActions.UIScrollStatic.Select.started += this.OnAction;
        InputManager.InputActions.UIScrollStatic.Back.started += this.OnBack;

        InputManager.ToggleActionMap(InputManager.InputActions.UIScrollStatic);
    }
    private void OnDisable()
    {
        InputManager.InputActions.UIScrollStatic.downScroll.started -= this.ScrollDown;
        InputManager.InputActions.UIScrollStatic.upScroll.started -= this.ScrollUp;
        InputManager.InputActions.UIScrollStatic.Select.started -= this.OnAction;
        InputManager.InputActions.UIScrollStatic.Back.started -= this.OnBack;
    }
    void Start()
    {
        this.cursor = this.transform.GetChild(childIdx).gameObject;
        this.cursor.GetComponentInChildren<TextMeshProUGUI>().color = this.selected;
        this.cursor.transform.GetChild(0).localScale = this.scale;

        this.src = GetComponent<AudioSource>();
    }
    public void ScrollUp(InputAction.CallbackContext context)
    {
        if (!DSController.HasBeenActivate)
            return;

        if (childIdx == 0)
            childIdx = this.transform.childCount;
        this.cursor.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        this.cursor.transform.GetChild(0).localScale = Vector3.one;
        this.cursor = this.transform.GetChild(--this.childIdx).gameObject;
        this.cursor.GetComponentInChildren<TextMeshProUGUI>().color = this.selected;
        this.cursor.transform.GetChild(0).localScale = this.scale;

        this.src.PlayOneShot(this.selecMove);
    }
    public void ScrollDown(InputAction.CallbackContext context)
    {
        if (!DSController.HasBeenActivate)
            return;

        if (childIdx == this.transform.childCount - 1)
            childIdx = -1;

        this.cursor.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        this.cursor.transform.GetChild(0).localScale = Vector3.one;
        this.cursor = this.transform.GetChild(++this.childIdx).gameObject;
        this.cursor.GetComponentInChildren<TextMeshProUGUI>().color = this.selected;
        this.cursor.transform.GetChild(0).localScale = this.scale;

        this.src.PlayOneShot(this.selecMove);
    }
    public void OnAction(InputAction.CallbackContext context)
    {
        this.src.PlayOneShot(this.selecMove);
        this.cursor.GetComponent<Button>().onClick.Invoke();
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        if (this.eventOnBack.GetPersistentEventCount() != 0)
            this.src.PlayOneShot(this.selecMove);
        this.eventOnBack?.Invoke();
    }
}

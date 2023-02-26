using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ScrollSaveGame : MonoBehaviour
{
    private ScrollRect scroll;
    private GameObject cursor;
    private int childIdx = 0;
    private float displacement;
    [SerializeField] private Color selected = Color.white;
    [SerializeField] private float repeateTimer = 0.3f;
    [SerializeField] private AudioClip selecMove;
    private AudioSource src;
    private float timer;
    private bool up = false;
    private bool down = false;
    private void OnEnable()
    {
        InputManager.InputActions.UIScrollSaveGame.downScroll.started += this.ScrollDown;
        InputManager.InputActions.UIScrollSaveGame.downScroll.canceled += this.ScrollDown;
        InputManager.InputActions.UIScrollSaveGame.upScroll.started += this.ScrollUp;
        InputManager.InputActions.UIScrollSaveGame.upScroll.canceled += this.ScrollUp;
        InputManager.InputActions.UIScrollSaveGame.Select.started += this.OnAction;
        InputManager.InputActions.UIScrollSaveGame.Back.started += this.OnBack;

        InputManager.ToggleActionMap(InputManager.InputActions.UIScrollSaveGame);
    }
    private void OnDisable()
    {
        InputManager.InputActions.UIScrollSaveGame.downScroll.started -= this.ScrollDown;
        InputManager.InputActions.UIScrollSaveGame.downScroll.canceled -= this.ScrollDown;
        InputManager.InputActions.UIScrollSaveGame.upScroll.started -= this.ScrollUp;
        InputManager.InputActions.UIScrollSaveGame.upScroll.canceled -= this.ScrollUp;
        InputManager.InputActions.UIScrollSaveGame.Select.started -= this.OnAction;
        InputManager.InputActions.UIScrollSaveGame.Back.started -= this.OnBack;
    }
    public void Start()
    {
        this.scroll = GetComponent<ScrollRect>();

        if (this.scroll.content.childCount == 0)
        {
            InputManager.ToggleActionMap(InputManager.InputActions.UIScrollStatic);
            this.transform.parent.gameObject.SetActive(false);
            return;
        }
        this.cursor = this.scroll.content.GetChild(childIdx).gameObject;
        this.cursor.GetComponent<Image>().color = this.selected;
        this.src = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (this.scroll.content.childCount == 0)
        {
            InputManager.ToggleActionMap(InputManager.InputActions.UIScrollStatic);
            this.transform.parent.gameObject.SetActive(false);
            return;
        }

        if (this.up && (Time.time - this.timer >= this.repeateTimer) )
        {
            if (childIdx == 0)
                return;
            this.cursor.GetComponent<Image>().color = Color.white;
            this.cursor = this.scroll.content.GetChild(--this.childIdx).gameObject;
            this.cursor.GetComponent<Image>().color = this.selected;

            this.displacement = Vector3.Distance(this.scroll.content.GetChild(this.childIdx + 1).transform.position, this.scroll.content.GetChild(this.childIdx).transform.position);
            this.scroll.content.transform.Translate(new Vector3(0, -this.displacement, 0));

            this.timer = Time.time;
            this.src.PlayOneShot(this.selecMove);
        }
        else if (this.down && (Time.time - this.timer >= this.repeateTimer))
        {
            if (childIdx == this.scroll.content.childCount - 1)
                return;

            this.cursor.GetComponent<Image>().color = Color.white;
            this.cursor = this.scroll.content.GetChild(++this.childIdx).gameObject;
            this.cursor.GetComponent<Image>().color = this.selected;

            this.displacement = Vector3.Distance(this.scroll.content.GetChild(this.childIdx - 1).transform.position, this.scroll.content.GetChild(this.childIdx).transform.position);
            this.scroll.content.transform.Translate(new Vector3(0, this.displacement, 0));

            this.timer = Time.time;
            this.src.PlayOneShot(this.selecMove);
        }
    }
    public void ScrollUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            this.up = true;
            this.timer = 0;
        }
        else if (context.canceled)
            this.up = false;
    }
    public void ScrollDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            this.down = true;
            this.timer = 0;
        }
        else if (context.canceled)
            this.down = false;
    }
    public void OnAction(InputAction.CallbackContext context)
    {
        this.cursor.GetComponent<SaveGameButton>().OnClick();
        this.src.PlayOneShot(this.selecMove);
        InputManager.ToggleActionMap(InputManager.InputActions.Player);
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        InputManager.ToggleActionMap(InputManager.InputActions.UIScrollStatic);
        this.src.PlayOneShot(this.selecMove);
        this.transform.parent.gameObject.SetActive(false);
    }
}
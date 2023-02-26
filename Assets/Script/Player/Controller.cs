using UnityEngine;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
    private PlayerConfig config;
    private PlayerSoundConfig soundConfig;

    private AudioSource audioSource;
    private int sampleCount = 1024;
    private float[] samples;

    private Vector2 pressure;
    private Vector2 weaponRotation;
    private float lastFingerPos;

    private bool bothThruster = false;
    private bool leftThruster = false;
    private bool rightThruster = false;

    private bool stopInput = false;
    
    public Vector2 Pressure { get => pressure; set => pressure = value; }
    public bool BothThruster { get => bothThruster; set => bothThruster = value; }
    public bool LeftThruster { get => leftThruster; set => leftThruster = value; }
    public bool RightThruster { get => rightThruster; set => rightThruster = value; }
    public bool StopInput { get => stopInput; set => stopInput = value; }
    public Vector2 WeaponRotation { get => weaponRotation; set => weaponRotation = value; }

    private void OnEnable()
    {
        InputManager.InputActions.Player.UpMove.performed += this.UpMove;
        InputManager.InputActions.Player.UpMove.canceled += this.UpMove;
        InputManager.InputActions.Player.LeftMove.started += this.LeftMove;
        InputManager.InputActions.Player.LeftMove.canceled += this.LeftMove;
        InputManager.InputActions.Player.RightMove.started += this.RightMove;
        InputManager.InputActions.Player.RightMove.canceled += this.RightMove;
        InputManager.InputActions.Player.RotateWeapon.performed += this.RotateWeapon;
        InputManager.InputActions.Player.PauseMenu.started += this.PauseMenu;

        InputManager.ToggleActionMap(InputManager.InputActions.Player);
    }
    public void OnDisable()
    {
        InputManager.InputActions.Player.UpMove.performed -= this.UpMove;
        InputManager.InputActions.Player.UpMove.canceled -= this.UpMove;
        InputManager.InputActions.Player.LeftMove.started -= this.LeftMove;
        InputManager.InputActions.Player.LeftMove.canceled -= this.LeftMove;
        InputManager.InputActions.Player.RightMove.started -= this.RightMove;
        InputManager.InputActions.Player.RightMove.canceled -= this.RightMove;
        InputManager.InputActions.Player.RotateWeapon.performed -= this.RotateWeapon;
        InputManager.InputActions.Player.PauseMenu.started -= this.PauseMenu;
    }
    void Start()
    {
        //start recording microphone
        this.audioSource = GetComponents<AudioSource>()[0];
        this.audioSource.clip = Microphone.Start(null, true, 1, 44100);
        this.audioSource.loop = true;
        samples = new float[sampleCount];
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();

        this.config = GameManager.PlayerConfig;
        this.soundConfig = GameManager.SoundConfig;

        StartCoroutine(DSController.InitController());
    }
    void Update()
    {
        this.Pressure = DSController.getPressure();
    }
    public bool IsShackingX()
    {
        float delta = DSController.scale - DSController.accelerator();
        return (delta < (this.config.ShakeThreshold * 2) && delta > this.config.ShakeThreshold);
    }
    public bool IsSwipeY()
    {
        if (!DSController.IsFinger1Down())
            return false;

        float posY = DSController.GetTouch1PositionY();
        bool isSwiping = this.lastFingerPos - posY > this.config.SwipeDist;
        this.lastFingerPos = posY;
        return isSwiping;
    }
    public bool IsBlowing()
    {
        this.audioSource.GetOutputData(samples, 0);

        float sum = 0;
        for (int i = 0; i < sampleCount; i++)
            sum += Mathf.Pow(samples[i], 2);

        float rmsValue = Mathf.Sqrt(sum / sampleCount) * 100;
        return rmsValue >= config.BlowPower;
    }
    public void UpMove(InputAction.CallbackContext context)
    {
        if (this.stopInput)
            return;

        if (context.performed)
        {
            if (!this.soundConfig.ThrustEffect.isPlaying)
                this.soundConfig.ThrustEffect.Play();

            this.bothThruster = true;

            if (!this.config.MainThrusterP.isPlaying)
                this.config.MainThrusterP.Play();

            if (!this.config.LeftThrusterP.isPlaying)
                this.config.LeftThrusterP.Play();

            if (!this.config.RightThrusterP.isPlaying)
                this.config.RightThrusterP.Play();
        }
        else if (context.canceled)
        {
            this.bothThruster = false;

            if (!this.rightThruster && !this.leftThruster && this.config.MainThrusterP.isPlaying)
            {
                this.config.MainThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                this.soundConfig.ThrustEffect.Stop();
            }

            if (this.config.RightThrusterP.isPlaying && !this.rightThruster)
                this.config.RightThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            if (this.config.LeftThrusterP.isPlaying && !this.leftThruster)
                this.config.LeftThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
    public void LeftMove(InputAction.CallbackContext context)
    {
        if (this.stopInput)
            return;

        if (context.started)
        {
            if (!this.soundConfig.ThrustEffect.isPlaying)
                this.soundConfig.ThrustEffect.Play();

            this.leftThruster = true;

            if (!this.config.MainThrusterP.isPlaying)
                this.config.MainThrusterP.Play();

            if (!this.config.LeftThrusterP.isPlaying)
                this.config.LeftThrusterP.Play();

            if (this.config.RightThrusterP.isPlaying && !this.bothThruster)
                this.config.RightThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        else if (context.canceled)
        {
            this.leftThruster = false;
            this.config.LeftThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            if (!this.rightThruster && this.config.MainThrusterP.isPlaying)
            {
                this.config.MainThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                this.soundConfig.ThrustEffect.Stop();
            }
        }
    }
    public void RightMove(InputAction.CallbackContext context)
    {
        if (this.stopInput)
            return;

        if (context.started)
        {
            if (!this.soundConfig.ThrustEffect.isPlaying)
                this.soundConfig.ThrustEffect.Play();

            this.rightThruster = true;

            if (!this.config.MainThrusterP.isPlaying)
                this.config.MainThrusterP.Play();

            if (!this.config.RightThrusterP.isPlaying)
                this.config.RightThrusterP.Play();

            if (this.config.LeftThrusterP.isPlaying && !this.bothThruster)
                this.config.LeftThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        else if (context.canceled)
        {
            this.rightThruster = false;
            this.config.RightThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            if (!this.leftThruster && this.config.MainThrusterP.isPlaying)
            {
                this.config.MainThrusterP.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                this.soundConfig.ThrustEffect.Stop();
            }
        }
    }
    public void RotateWeapon(InputAction.CallbackContext context)
    {
        if (this.stopInput)
            return;

        WeaponRotation = (context.ReadValue<Vector2>() * this.config.MaxAngle);
    }
    public void PauseMenu(InputAction.CallbackContext context)
    {
        DSController.Controller.PauseHaptics();
        Time.timeScale = 0;
        this.config.PauseMenu.SetActive(true);
    }
}
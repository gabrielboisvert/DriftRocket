using UnityEngine;

[System.Serializable]
public class PlayerConfig
{
    [SerializeField] private float thrusterPower = 370;
    [SerializeField] private float rotationPower = 125;
    [SerializeField] private float maxAngle = 75;
    [SerializeField] private float bouncingForce = 3;

    [SerializeField] private GameObject weapon;
    [SerializeField] private int swipeDist = 15;
    [SerializeField] private float weaponDuration = 5;

    [SerializeField] private GameObject missile;
    [SerializeField] private float fireRate = 0.5f;

    [SerializeField] private GameObject shield;
    [SerializeField] private int shakeThreshold = 150;

    [SerializeField] private float leftRumblePower = 0.2f;
    [SerializeField] private float rightRumblePower = 0.8f;

    [SerializeField] private float boostMultiplicator = 2;
    [SerializeField] private float boostDuration = 10;
    [SerializeField] private float blowPower = 10;

    [SerializeField] private CameraShake camera;
    [SerializeField] private float cameraShakePower = 1;

    [SerializeField] private ParticleSystem mainThrusterP;
    [SerializeField] private ParticleSystem leftThrusterP;
    [SerializeField] private ParticleSystem rightThrusterP;
    [SerializeField] private ParticleSystem deadParticule;
    [SerializeField] private ParticleSystem winParticule;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;

    [SerializeField] private Gradient speedBoostColor;
    [SerializeField] private Vector3 thrusterScale = new Vector3(2, 5, 2);

    [SerializeField] private float winAnimationDuration = 3;
    [SerializeField] private float winAnimationPlayerRotation = 50;
    [SerializeField] private float winAnimationPlayerSpeed = 50;
    
    private int maxMissile;

    public float ThrusterPower { get => thrusterPower; set => thrusterPower = value; }
    public float BoostMultiplicator { get => boostMultiplicator; set => boostMultiplicator = value; }
    public float RotationPower { get => rotationPower; set => rotationPower = value; }
    public float MaxAngle { get => maxAngle; set => maxAngle = value; }
    public int ShakeThreshold { get => shakeThreshold; set => shakeThreshold = value; }
    public GameObject Shield { get => shield; set => shield = value; }
    public int SwipeDist { get => swipeDist; set => swipeDist = value; }
    public GameObject Weapon { get => weapon; set => weapon = value; }
    public int MaxMissile { get => maxMissile; set => maxMissile = value; }
    public GameObject Missile { get => missile; set => missile = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float WeaponDuration { get => weaponDuration; set => weaponDuration = value; }
    public float BlowPower { get => blowPower; set => blowPower = value; }
    public float BoostDuration { get => boostDuration; set => boostDuration = value; }
    public CameraShake Camera { get => camera; set => camera = value; }
    public float CameraShakePower { get => cameraShakePower; set => cameraShakePower = value; }
    public ParticleSystem DeadParticule { get => deadParticule; set => deadParticule = value; }
    public ParticleSystem MainThrusterP { get => mainThrusterP; set => mainThrusterP = value; }
    public ParticleSystem LeftThrusterP { get => leftThrusterP; set => leftThrusterP = value; }
    public ParticleSystem RightThrusterP { get => rightThrusterP; set => rightThrusterP = value; }
    public float BouncingForce { get => bouncingForce; set => bouncingForce = value; }
    public ParticleSystem WinParticule { get => winParticule; set => winParticule = value; }
    public GameObject PauseMenu { get => pauseMenu; set => pauseMenu = value; }
    public GameObject WinMenu { get => winMenu; set => winMenu = value; }
    public float LeftRumblePower { get => leftRumblePower; set => leftRumblePower = value; }
    public float RightRumblePower { get => rightRumblePower; set => rightRumblePower = value; }
    public Gradient SpeedBoostColor { get => speedBoostColor; set => speedBoostColor = value; }
    public Vector3 ThrusterScale { get => thrusterScale; set => thrusterScale = value; }
    public float WinAnimationDuration { get => winAnimationDuration; set => winAnimationDuration = value; }
    public float WinAnimationPlayerRotation { get => winAnimationPlayerRotation; set => winAnimationPlayerRotation = value; }
    public float WinAnimationPlayerSpeed { get => winAnimationPlayerSpeed; set => winAnimationPlayerSpeed = value; }
    public PlayerConfig()
    {
        this.MaxMissile = (int)(this.WeaponDuration / this.FireRate);
    }
}
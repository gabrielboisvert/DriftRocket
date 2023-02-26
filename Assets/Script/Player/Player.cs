using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Controller controller;
    [SerializeField] private GameObject playerBody;
    [SerializeField] private PlayerConfig config = new PlayerConfig();
    [SerializeField] private PlayerSoundConfig soundConfig = new PlayerSoundConfig();
    private Rigidbody body;
    private bool dead = false;
    private bool finish = false;
    private bool boosted = false;
    private bool shielded = false;
    private bool armed = false;
    private bool missilePowerUp = false;
    private bool ShieldPowerUp = false;
    private bool boostPowerUp = false;
    private bool recover = false;
    private int starCounter = 0;
    public event EventHandler OnReady;
    public event EventHandler OnFinish;
    private bool hasStart = false;
    private Coroutine rumble;
    private AudioSource effectSrc;
    public bool IsDead { get => dead; set => dead = value; }
    public int StarCounter { get => starCounter; set => starCounter = value; }
    public bool Recover { get => recover; set => recover = value; }

    private void Start()
    {
        this.controller = GetComponent<Controller>();
        this.body = GetComponent<Rigidbody>();

        this.effectSrc = GetComponents<AudioSource>()[1];

        GameManager.Player = this;
        GameManager.PlayerConfig = this.config;
        GameManager.SoundConfig = this.soundConfig;
        GameManager.SaveProgress();
        GetComponent<Rigidbody>().Sleep();

        if (GameManager.CheckPoints.Count != 0)
            this.transform.position = GameManager.CheckPoints[GameManager.CheckPoints.Count - 1];

        GameManager.MainMenuMusic?.StopMusic();
    }
    void Update()
    {
        if (this.dead)
            return;

        if (!this.body.IsSleeping() && !this.hasStart)
        {
            this.hasStart = true;
            this.OnReady.Invoke(this, null);
        }

        if (this.controller.RightThruster || this.controller.LeftThruster || this.controller.BothThruster)
            this.body.AddRelativeForce(Vector3.up * this.config.ThrusterPower * Math.Max(this.controller.Pressure.x, this.controller.Pressure.y) * Time.deltaTime * (this.boosted ? this.config.BoostMultiplicator : 1), ForceMode.Force);

        if (!this.controller.BothThruster)
        {
            if (this.controller.LeftThruster)
                this.transform.Rotate(0, 0, (this.config.RotationPower * Time.deltaTime * this.controller.Pressure.x), Space.Self);
            else if (this.controller.RightThruster)
                this.transform.Rotate(0, 0, -(this.config.RotationPower * Time.deltaTime * this.controller.Pressure.y), Space.Self);
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Player.ClampAngle(this.transform.eulerAngles.z, -this.config.MaxAngle, this.config.MaxAngle));
        }

        if (!this.shielded && this.controller.IsShackingX())
            this.ActivateShield();

        if (!this.armed && this.controller.IsSwipeY())
            this.ActivateWeapon();
        else if (this.armed)
            this.config.Weapon.transform.rotation = Quaternion.Euler(0, 0, this.controller.WeaponRotation.x + this.transform.rotation.eulerAngles.z);

        if (!this.boosted && this.controller.IsBlowing())
            this.ActivateBoost();

        if (this.body.angularVelocity != Vector3.zero)
            this.body.angularVelocity = Vector3.zero;
    }
    static float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) 
            angle = 360 + angle;
        if (angle > 180f) 
            return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }
    private void ActivateShield()
    {
        if (!this.ShieldPowerUp)
            return;

        this.shielded = true;
        this.config.Shield.SetActive(true);
        this.effectSrc.PlayOneShot(this.soundConfig.ShieldEffect[1]);
        this.ShieldPowerUp = false;
        GameManager.Ui.SwitchPowerUP(PlayerUI.PowerUPName.PowerUPShield);
    }
    private IEnumerator DeactiveShield()
    {
        yield return new WaitForSeconds(0.1f);

        this.effectSrc.PlayOneShot(this.soundConfig.ShieldEffect[3]);
        this.shielded = false;
        this.config.Shield.SetActive(false);

        yield return new WaitForSeconds(0.2f);
        this.Recover = false;
    }
    private void ActivateWeapon()
    {
        if (!this.missilePowerUp)
            return;

        this.armed = true;
        this.config.Weapon.SetActive(true);
        this.controller.WeaponRotation = Vector2.zero;
        this.missilePowerUp = false;
        GameManager.Ui.SwitchPowerUP(PlayerUI.PowerUPName.PowerUPMissile);
        StartCoroutine(this.Fire());
        this.effectSrc.PlayOneShot(this.soundConfig.MissileEffect[2]);
        StartCoroutine(this.DeactivateWeapon());
    }
    private IEnumerator Fire()
    {
        for (int i = 0; i < this.config.MaxMissile; i++)
        {
            yield return new WaitForSeconds(this.config.FireRate);

            if (this.dead)
                yield return null;

            Instantiate(this.config.Missile, this.config.Weapon.transform.position, this.config.Weapon.transform.rotation);
            this.effectSrc.PlayOneShot(this.soundConfig.MissileEffect[0]);
        }
    }
    private IEnumerator DeactivateWeapon()
    {
        yield return new WaitForSeconds(this.config.WeaponDuration);

        this.armed = false;
        this.effectSrc.PlayOneShot(this.soundConfig.MissileEffect[3]);
        this.config.Weapon.SetActive(false);
    }
    private void ActivateBoost()
    {
        if (!this.boostPowerUp)
            return;

        this.boosted = true;
        this.boostPowerUp = false;
        this.effectSrc.PlayOneShot(this.soundConfig.BoostEffect[1]);
        GameManager.Ui.SwitchPowerUP(PlayerUI.PowerUPName.PowerUPBoost);

        this.rumble = StartCoroutine(this.ActivateRumble());
        StartCoroutine(this.DeactivateBoost(this.config.MainThrusterP.colorOverLifetime.color.gradient, this.config.MainThrusterP.gameObject.transform.localScale));
        StartCoroutine(this.config.Camera.Shake(this.config.BoostDuration));

        var col = this.config.MainThrusterP.colorOverLifetime;
        col.color = this.config.SpeedBoostColor;
        this.config.MainThrusterP.gameObject.transform.localScale = this.config.ThrusterScale;

        col = this.config.LeftThrusterP.colorOverLifetime;
        col.color = this.config.SpeedBoostColor;
        this.config.LeftThrusterP.gameObject.transform.localScale = this.config.ThrusterScale;

        col = this.config.RightThrusterP.colorOverLifetime;
        col.color = this.config.SpeedBoostColor;
        this.config.RightThrusterP.gameObject.transform.localScale = this.config.ThrusterScale;
    }
    private IEnumerator DeactivateBoost(Gradient oldColor, Vector3 oldScale)
    {
        yield return new WaitForSeconds(this.config.BoostDuration);
        this.boosted = false;

        this.effectSrc.PlayOneShot(this.soundConfig.BoostEffect[2]);
        StopCoroutine(this.rumble);
        DSController.Controller.ResetHaptics();

        var col = this.config.MainThrusterP.colorOverLifetime;
        col.color = oldColor;
        this.config.MainThrusterP.gameObject.transform.localScale = oldScale;

        col = this.config.LeftThrusterP.colorOverLifetime;
        col.color = oldColor;
        this.config.LeftThrusterP.gameObject.transform.localScale = oldScale;

        col = this.config.RightThrusterP.colorOverLifetime;
        col.color = oldColor;
        this.config.RightThrusterP.gameObject.transform.localScale = oldScale;
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(this.config.DeadParticule.main.startLifetime.constant * 2);
        DSController.Controller.ResetHaptics();

        GameManager.Fade.FadeStart(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
            return;

        this.Hit(collision.GetContact(0).normal);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameManager.SaveProgress();
            StartCoroutine(this.FinishAnimation());
            OnFinish.Invoke(this, null);
            this.finish = true;
        }
    }
    public void Hit(Vector3 normal)
    {
        if (this.Recover || this.dead || this.finish)
            return;

        if (!this.shielded)
        {
            this.dead = true;
            this.config.DeadParticule.Play();
            this.soundConfig.DeadEffect.Play();

            this.config.MainThrusterP.Stop();
            this.config.RightThrusterP.Stop();
            this.config.LeftThrusterP.Stop();
            this.controller.OnDisable();

            this.playerBody.SetActive(false);
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Collider>());
            this.armed = false;
            this.config.Weapon.SetActive(false);

            StartCoroutine(GameManager.PlayerConfig.Camera.Shake(this.config.DeadParticule.main.startLifetime.constant));
            StartCoroutine(this.Respawn());
            return;
        }

        DSController.Controller.SetMotorSpeeds(GameManager.PlayerConfig.LeftRumblePower, GameManager.PlayerConfig.RightRumblePower);
        StartCoroutine(this.DeactiveRumble(0.5f));

        Quaternion rotation = this.body.rotation;
        this.body.rotation = Quaternion.identity;
        this.body.AddRelativeForce(normal * this.config.BouncingForce, ForceMode.Impulse);
        this.body.rotation = rotation;
        this.body.maxAngularVelocity = 0;

        this.Recover = true;
        this.effectSrc.PlayOneShot(this.soundConfig.ShieldEffect[2]);
        StartCoroutine(this.DeactiveShield());
    }
    public bool AddCollectable(PowerUp item)
    {
        switch (item)
        {
            case PowerUpMissile t:
                if (!this.missilePowerUp)
                {
                    this.missilePowerUp = true;
                    this.effectSrc.PlayOneShot(this.soundConfig.MissileEffect[1]);
                }
                else
                    return false;
                break;
            case PowerUpShield t:
                if (!this.ShieldPowerUp)
                {
                    this.ShieldPowerUp = true;
                    this.effectSrc.PlayOneShot(this.soundConfig.ShieldEffect[0]);
                }
                else
                    return false;
                break;
            case PowerUpBoost t:
                if (!this.boostPowerUp)
                {
                    this.boostPowerUp = true;
                    this.effectSrc.PlayOneShot(this.soundConfig.BoostEffect[0]);
                }
                else
                    return false;
                break;
        }
        return true;
    }
    public void AddStar()
    {
        this.effectSrc.PlayOneShot(this.soundConfig.StarCollect);
        this.StarCounter++;
    }
    public IEnumerator DeactiveRumble(float duration)
    {
        yield return new WaitForSeconds(duration);
        DSController.Controller.ResetHaptics();
    }
    public IEnumerator ActivateRumble(float reactiveEvery = 2)
    {
        float elapse = 0;
        while (true)
        {
            elapse += Time.deltaTime;
            if (elapse >= reactiveEvery)
            {
                DSController.Controller.SetMotorSpeeds(GameManager.PlayerConfig.LeftRumblePower, GameManager.PlayerConfig.RightRumblePower);
                elapse = 0;
            }
            yield return null;
        }
    }
    public IEnumerator FinishAnimation()
    {
        this.controller.OnDisable();

        GetComponent<Collider>().enabled = false;
        DSController.Controller.SetMotorSpeeds(this.config.LeftRumblePower, this.config.RightRumblePower);
        this.effectSrc.PlayOneShot(this.soundConfig.SuccessEffect);
        this.config.MainThrusterP.Play();
        this.config.LeftThrusterP.Play();
        this.config.RightThrusterP.Play();
        this.soundConfig.ThrustEffect.Play();
        this.config.WinParticule.Play();

        Quaternion target = Quaternion.FromToRotation(this.transform.rotation.eulerAngles, Vector3.zero);

        float elapse = 0;
        while (elapse < this.config.WinAnimationDuration)
        {
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target, Time.deltaTime * this.config.WinAnimationPlayerRotation);
            this.transform.Translate(Vector3.up * this.config.WinAnimationPlayerSpeed * Time.deltaTime);

            elapse += Time.deltaTime;
            yield return null;
        }
        DSController.Controller.ResetHaptics();
        this.soundConfig.ThrustEffect.Stop();
        this.config.WinMenu.SetActive(true);
    }
}
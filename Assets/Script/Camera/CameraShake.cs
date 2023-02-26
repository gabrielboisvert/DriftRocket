using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool shouldShake = false;
    private Vector3 oldPos;
    private float timer;

    public void Start()
    {
        this.oldPos = this.transform.localPosition;
    }
    public void ShouldShake(bool isShake)
    {
        if (isShake)
        {
            this.oldPos = transform.localPosition;
            this.timer = Time.time;

            DSController.Controller.SetMotorSpeeds(GameManager.PlayerConfig.LeftRumblePower, GameManager.PlayerConfig.RightRumblePower);
        }
        else
        {
            transform.localPosition = this.oldPos;
            DSController.Controller.ResetHaptics();
        }
        this.shouldShake = isShake;
    }

    public void Update()
    {
        if (!this.shouldShake || Time.timeScale == 0 || GameManager.Player.IsDead)
            return;

        if (Time.time - this.timer >= 2)
        {
            DSController.Controller.SetMotorSpeeds(GameManager.PlayerConfig.LeftRumblePower, GameManager.PlayerConfig.RightRumblePower);
            this.timer = Time.time;
        }

        float x = Random.Range(-1, 1) * GameManager.PlayerConfig.CameraShakePower;
        float y = Random.Range(-1, 1) * GameManager.PlayerConfig.CameraShakePower;
        transform.localPosition = new Vector3(x, y, this.oldPos.z);
    }

    public IEnumerator Shake(float duration)
    {
        DSController.Controller.SetMotorSpeeds(GameManager.PlayerConfig.LeftRumblePower, GameManager.PlayerConfig.RightRumblePower);
        Vector3 pos = transform.localPosition;
        float elapse = 0;
        while (elapse < duration)
        {
            if (Time.timeScale != 0)
            {
                float x = Random.Range(-1, 1) * GameManager.PlayerConfig.CameraShakePower;
                float y = Random.Range(-1, 1) * GameManager.PlayerConfig.CameraShakePower;
                transform.localPosition = new Vector3(x, y, pos.z);

                elapse += Time.deltaTime;
            }
            yield return null;
        }

        transform.localPosition = pos;
        DSController.Controller.ResetHaptics();
    }
}

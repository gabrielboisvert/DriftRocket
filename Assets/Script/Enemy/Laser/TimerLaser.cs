using UnityEngine;
public abstract class TimerLaser : Laser
{
    [SerializeField] protected float duration = 1;
    [SerializeField] protected float restTime = 1;
    [SerializeField] protected float preChargeTime = 0.5f;
    [SerializeField] protected LineRenderer preCharge;
    [SerializeField] protected float preChargeWidthMax = 1;
    [SerializeField] protected AudioClip warmUpEffect;
    protected float durationTimer = 0;
    protected float restTimer = 0;
    protected float preChargeTimerStart = 0;
    protected bool shootingState = true;
    protected abstract void SwithLaserState(bool isActivate);
}
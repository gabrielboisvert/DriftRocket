using UnityEngine;
public class FixedTimerLaser : TimerLaser
{
    [SerializeField] private float length = 5;
    private BoxCollider box;
    public new void Start()
    {
        base.Start();
        Vector3 staticLaserPos = new Vector3(this.transform.parent.forward.x, this.transform.parent.forward.y, this.transform.parent.forward.z * this.length);
        this.lineRenderer.SetPosition(1, staticLaserPos);
        this.preCharge.SetPosition(1, staticLaserPos);

        this.box = GetComponent<BoxCollider>();
        this.box.center = new Vector3(0, 0, this.length / 2);
        this.box.size = new Vector3(1, 1, this.length);
    }
    public void Update()
    {
        if (this.shootingState)
        {
            this.durationTimer += Time.deltaTime;
            if (this.durationTimer >= this.duration)
            {
                this.SwithLaserState(false);
                this.durationTimer = 0;

                this.src.clip = this.warmUpEffect;
                this.src.Play();
                this.preCharge.enabled = true;
                this.preChargeTimerStart = Time.time;
            }
        }
        else
        {
            this.restTimer += Time.deltaTime;
            if (this.restTimer >= this.restTime)
            {
                this.SwithLaserState(true);
                this.restTimer = 0;
                this.src.clip = this.LaserEffect;
                this.src.Play();
            }

            if ((Time.time - this.preChargeTimerStart) >= this.preChargeTime)
            {
                this.preCharge.enabled = false;
                this.src.Stop();
                return;
            }

            float interpolate = Mathf.SmoothStep(0, this.preChargeWidthMax, (Time.time - this.preChargeTimerStart) / this.preChargeTime);
            this.preCharge.startWidth = interpolate;
            this.preCharge.endWidth = interpolate;
        }
    }
    protected override void SwithLaserState(bool isActivate)
    {
        this.shootingState = isActivate;
        this.lineRenderer.enabled = isActivate;
        this.box.enabled = isActivate;
    }
}

using UnityEngine;

public class InfiniteTimerLaser : TimerLaser
{
    private ParticleSystem particule;
    public new void Start()
    {
        base.Start();
        this.particule = GetComponentInChildren<ParticleSystem>();
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
                this.particule.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

                this.src.clip = this.warmUpEffect;
                this.src.Play();
                this.preCharge.enabled = true;
                this.preChargeTimerStart = Time.time;
            }

            //update renderLine length
            RaycastHit hit;
            if(!Physics.Raycast(this.transform.parent.position, this.transform.parent.right, out hit, Mathf.Infinity, ~ignoredMask))
                return;

            Vector3 localPos = transform.InverseTransformPoint(hit.point);
            
            this.particule.transform.localPosition = new Vector3(1, localPos.y, localPos.z);
            this.lineRenderer.SetPosition(1, localPos);

            if (hit.collider.CompareTag("Player"))
                GameManager.Player.Hit(-hit.normal);

        }
        else
        {
            this.restTimer += Time.deltaTime;
            if (this.restTimer >= this.restTime)
            {
                this.SwithLaserState(true);
                this.restTimer = 0;
                this.particule.Play();

                this.src.clip = this.LaserEffect;
                this.src.Play();
            }

            if ((Time.time - this.preChargeTimerStart) >=  this.preChargeTime)
            {
                this.preCharge.enabled = false;
                //this.src.Stop();
                return;
            }

            float interpolate = Mathf.SmoothStep(0, this.preChargeWidthMax, (Time.time - this.preChargeTimerStart) / this.preChargeTime);
            this.preCharge.startWidth = interpolate;
            this.preCharge.endWidth = interpolate;

            //update precharge length
            RaycastHit hit;
            if (!Physics.Raycast(this.transform.parent.position, this.transform.parent.right, out hit, Mathf.Infinity, ~ignoredMask))
                return;

            Vector3 localPos = transform.InverseTransformPoint(hit.point);
            this.preCharge.SetPosition(1, localPos);
        }
    }
    protected override void SwithLaserState(bool isActivate)
    {
        this.shootingState = isActivate;
        this.lineRenderer.enabled = isActivate;
    }
}
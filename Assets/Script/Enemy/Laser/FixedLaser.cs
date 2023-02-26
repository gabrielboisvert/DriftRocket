using UnityEngine;
public class FixedLaser : Laser
{
    [SerializeField] private float length = 5;
    private BoxCollider box;
    public new void Start()
    {
        base.Start();
        Vector3 staticLaserPos = new Vector3(this.transform.parent.forward.x, this.transform.parent.forward.y, this.transform.parent.forward.z * this.length);
        this.lineRenderer.SetPosition(1, staticLaserPos);

        this.box = GetComponent<BoxCollider>();
        this.box.center = new Vector3(0, 0, this.length / 2);
        this.box.size = new Vector3(1, 1, this.length);

        this.src.Play();
    }
}
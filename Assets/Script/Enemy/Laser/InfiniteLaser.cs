using UnityEngine;
public class InfiniteLaser : Laser
{
    private ParticleSystem particule;
    public new void Start()
    {
        base.Start();
        this.particule = GetComponentInChildren<ParticleSystem>();

        this.src.Play();
    }
    public void Update()
    {
        //update renderLine length
        RaycastHit hit;
        if (!Physics.Raycast(this.transform.parent.position, this.transform.parent.right, out hit, Mathf.Infinity, ~ignoredMask))
            return;

        Vector3 localPos = transform.InverseTransformPoint(hit.point);

        this.particule.transform.localPosition = new Vector3(1, localPos.y, localPos.z);
        this.lineRenderer.SetPosition(1, localPos);

        if (hit.collider.CompareTag("Player"))
            GameManager.Player.Hit(-hit.normal);
    }
}

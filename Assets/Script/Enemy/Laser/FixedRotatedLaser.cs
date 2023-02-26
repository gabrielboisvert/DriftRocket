using UnityEngine;
public class FixedRotatedLaser : FixedLaser
{
    [SerializeField] private float rotationSpeed = 100;
    [SerializeField] private Vector3 oriantation = Vector3.forward;
    [SerializeField] private GameObject pivot;
    public void Update()
    {
        this.pivot.transform.Rotate(this.oriantation * this.rotationSpeed * Time.deltaTime);
    }
}
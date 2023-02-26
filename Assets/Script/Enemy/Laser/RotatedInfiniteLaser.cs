using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedInfiniteLaser : InfiniteLaser
{
    [SerializeField] private float rotationSpeed = 100;
    [SerializeField] private Vector3 oriantation = Vector3.forward;
    [SerializeField] private GameObject pivot;
    public new void Update()
    {
        this.pivot.transform.Rotate(this.oriantation * this.rotationSpeed * Time.deltaTime);
        base.Update();
    }
}
using System;
using UnityEngine;

public class LadderAnimation : MonoBehaviour
{
    [SerializeField] private float duration = 2;
    [SerializeField] private Vector3 rotationMax;
    private float time;
    private bool hasStart = false;
    private void Start()
    {
        GameManager.Player.OnReady += new EventHandler(delegate (System.Object o, EventArgs a) { this.hasStart = true; this.time = Time.time; });
    }
    void Update()
    {
        if (!this.hasStart)
            return;

        float t = (Time.time - this.time) / this.duration;
        this.transform.rotation = Quaternion.Euler(Vector3.Lerp(Vector3.zero, rotationMax, t));

        if (t > 1)
            Destroy(this.gameObject);
    }
}

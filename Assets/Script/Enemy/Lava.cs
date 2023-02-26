using System;
using UnityEngine;
public class Lava : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.up;
    [SerializeField] private float speed = 1;
    [SerializeField] private bool started = false;
    private bool shouldStart = false;
    public float Speed { get => speed; set => speed = value; }
    void Start()
    {
        this.direction.Normalize();
        GameManager.Player.OnReady += new EventHandler(delegate (System.Object o, EventArgs a) { 
            this.shouldStart = true; });
    }
    void Update()
    {
        if (GameManager.Player.IsDead || GameManager.Player.Recover)
            return;

        if (this.started && this.shouldStart)
            this.transform.Translate(this.direction * this.Speed * Time.deltaTime, Space.Self);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.PlayerConfig.Camera.ShouldShake(true);
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.PlayerConfig.Camera.ShouldShake(false);
    }
}
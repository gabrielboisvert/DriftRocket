using System;
using UnityEngine;
using UnityEngine.UI;

public class FlickingAnimation : MonoBehaviour
{
    [SerializeField] private RawImage left;
    [SerializeField] private RawImage right;
    private RawImage current;
    [SerializeField] private float minAlpha = 150;
    [SerializeField] private float duration = 0.5f;
    float time;
    void Start()
    {
        GameManager.Player.OnReady += new EventHandler(delegate (System.Object o, EventArgs a) { Destroy(this.gameObject); });
        this.current = this.right;

        this.SwitchSide();
    }

    void Update()
    {
        if (Time.time - this.time >= this.duration)
            this.SwitchSide();
    }

    private void SwitchSide()
    {
        this.time = Time.time;

        Color c = this.current.color;
        c.a = 1;
        this.current.color = c;

        if (this.current == this.right)
            this.current = this.left;
        else
            this.current = this.right;

        c = this.current.color;
        c.a = this.minAlpha / 255;
        this.current.color = c;
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private float emptyAlpha = 50;
    [SerializeField] private Vector3 maxScale = new Vector3(0.6f, 0.6f, 0.6f);
    [SerializeField] private float duration = 0.25f;
    [SerializeField] TextMeshProUGUI text;
    private RawImage img;
    private bool active = false;
    private Vector3 defaultScale;

    void Start()
    {
        this.img = GetComponent<RawImage>();
        this.defaultScale = this.transform.localScale;

        Color c = this.img.color;
        c.a = this.emptyAlpha / 255;
        this.img.color = c;

        c = this.text.color;
        c.a = this.emptyAlpha / 255;
        this.text.color = c;
    }
    public void SwitchTexture()
    {
        this.active = !this.active;

        if (this.active)
        {
            Color c = this.img.color;
            c.a = 1;
            this.img.color = c;

            c = this.text.color;
            c.a = 1;
            this.text.color = c;
            StartCoroutine(this.startAnimation());
        }
        else
        {
            Color c = this.img.color;
            c.a = this.emptyAlpha / 255;
            this.img.color = c;

            c = this.text.color;
            c.a = this.emptyAlpha / 255;
            this.text.color = c;
        }
    }

    public IEnumerator startAnimation()
    {
        float elapse = Time.time;
        while (Time.time - elapse < this.duration)
        {
            if (Time.timeScale != 0)
            {
                float t = (Time.time - elapse) / this.duration;
                this.transform.localScale = Vector3.Lerp(this.defaultScale, this.maxScale, t);
            }
            yield return null;
        }

        elapse = Time.time;
        while (Time.time - elapse < this.duration)
        {
            if (Time.timeScale != 0)
            {
                float t = (Time.time - elapse) / this.duration;
                this.transform.localScale = Vector3.Lerp(this.maxScale, this.defaultScale, t);
            }
            yield return null;
        }
    }
}

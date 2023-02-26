using UnityEngine;
using UnityEngine.UI;
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float parralaxSpeed = 2f;
    private Material mat;
    void Start()
    {
        this.mat = GetComponent<Image>().material;
    }
    void Update()
    {
        mat.mainTextureOffset = new Vector2(-(Time.time / this.transform.localScale.x / this.parralaxSpeed), Time.time / this.transform.localScale.y / this.parralaxSpeed);
    }
}

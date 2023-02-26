using UnityEngine;
public abstract class Laser : MonoBehaviour
{
    [SerializeField] protected LayerMask ignoredMask;
    [SerializeField] protected AudioClip LaserEffect;

    protected LineRenderer lineRenderer;
    protected AudioSource src;

    // Start is called before the first frame update
    public void Start()
    {
        this.lineRenderer = GetComponent<LineRenderer>();
        this.src = GetComponent<AudioSource>();
        this.src.clip = this.LaserEffect;
    }
}
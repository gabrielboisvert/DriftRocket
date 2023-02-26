using System.Collections;
using UnityEngine;
public class Chunk : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] private float destroyeTime = 1f;
    [SerializeField] private int explosionForce = 500;
    [SerializeField] private float upEffect = 1f;
    [SerializeField] private float radius = 30f;
    private bool destoyed = false;
    private AudioSource src;
    public bool Destoyed { get => destoyed; set => destoyed = value; }
    public void Awake()
    {
        this.body = GetComponent<Rigidbody>();
        this.src = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.Explose(collision.GetContact(0).point);
        if (this.src != null)
            this.src.PlayOneShot(this.src.clip);
    }
    public void Explose(Vector3 explosionPosition, float force = 1, float forceScale = 1, float radius = 0)
    {
        this.body.constraints &= ~RigidbodyConstraints.FreezePositionY;
        this.body.constraints &= ~RigidbodyConstraints.FreezePositionX;

        GetComponent<Collider>().enabled = false;
        if (radius == 0)
            this.body.AddExplosionForce(this.explosionForce, explosionPosition, this.radius, upEffect, ForceMode.Force);
        else
            this.body.AddExplosionForce(force * forceScale, explosionPosition, radius, upEffect, ForceMode.Force);
        
        StartCoroutine(this.DestroyChunk());
    }
    public IEnumerator DestroyChunk()
    {
        this.Destoyed = true;
        yield return new WaitForSeconds(this.destroyeTime);
        Destroy(this.gameObject);
    }
}
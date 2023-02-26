using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveRocket : Rocket
{
    [SerializeField] private float duration = 2;
    [SerializeField] private float explosionForce = 5;
    [SerializeField] private float explosionRadius = 5;
    [SerializeField] private ParticleSystem explotion;
    private float timer = 0;
    private bool hasExplose = false;
    public new void Update()
    {
        if (!this.hasExplose)
            base.Update();

        this.timer += Time.deltaTime;
        if (this.timer >= this.duration)
            this.Explode();
    }
    private new void OnCollisionEnter(Collision collider)
    {
        this.Explode();
    }
    public new void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Collectable"))
            return;
        this.Explode();
    }

    private void Explode()
    {
        GetComponent<MeshRenderer>().enabled = false;

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, this.explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && !hit.CompareTag("Untagged"))
                rb.AddExplosionForce(this.explosionForce, this.transform.position, this.explosionRadius);
        }

        this.hasExplose = true;
        this.explotion.Play();
        StartCoroutine(this.Kill());
    }
    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(this.explotion.main.startLifetime.constant);
        Destroy(gameObject);
    }
}

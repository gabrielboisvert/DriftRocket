using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Collectable 
{
    [SerializeField] private float rotationSpeed = 100;
    [SerializeField] private ParticleSystem collected;
    [SerializeField] private ParticleSystem shining;
    public void Update()
    {
        this.transform.Rotate(Vector3.forward * this.rotationSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Player.AddStar();
            GameManager.Ui.AddStar();
            this.collected.Play();
            this.shining.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            GetComponent<Renderer>().enabled = false;
            Destroy(GetComponent<Collider>());
        }
    }
    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(this.collected.main.duration);
        Destroy(this.gameObject);
    }
}

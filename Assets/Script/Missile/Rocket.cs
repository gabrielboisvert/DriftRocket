using System.Collections;
using UnityEngine;
public class Rocket : MonoBehaviour
{
    [SerializeField] private float rocketSpeed;
    private AudioSource src;
    public void Start()
    {
        this.src = GetComponent<AudioSource>();
    }
    public void Update()
    {
        this.transform.position += this.transform.up * rocketSpeed * Time.deltaTime;
    }
    public void OnCollisionEnter(Collision collider)
    {
        if (this.src.clip != null)
        {
            this.src.Play();
            Destroy(GetComponent<Collider>());
            GetComponent<Renderer>().enabled = false;
            StartCoroutine(this.CoroDestroy(this.src.clip.length));
        }
        else
            Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Collectable") || collider.CompareTag("Lava") || collider.CompareTag("PlayerSize"))
            return;

        if (this.src.clip != null)
        {
            this.src.Play();
            Destroy(GetComponent<Collider>());
            GetComponent<Renderer>().enabled = false;
            StartCoroutine(this.CoroDestroy(this.src.clip.length));
        }
        else
            Destroy(this.gameObject);
    }
    private IEnumerator CoroDestroy(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}

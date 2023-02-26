using UnityEngine;
public class ShatterManager : MonoBehaviour
{
    [SerializeField] private GameObject shattedModel;
    [SerializeField] private GameObject unShattedModel;
    [SerializeField] private float playerExplotionRadius = 10;
    [SerializeField] private float playerExplotionForce = 100;
    private Collider collider;
    private AudioSource src;
    private bool haveSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        this.shattedModel.SetActive(false);
        this.unShattedModel.SetActive(true);
        this.collider = GetComponent<Collider>();
        this.src = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (this.shattedModel.transform.childCount == 0)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (this.src != null)
            this.src.Play();

        if (!this.haveSwitch && !collision.CompareTag("PlayerSize"))
        {
            this.unShattedModel.SetActive(false);
            this.shattedModel.SetActive(true);
            this.haveSwitch = true;

            Destroy(this.collider);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (this.src != null)
            this.src.Play();

        if (!this.haveSwitch)
        {
            this.unShattedModel.SetActive(false);
            this.shattedModel.SetActive(true);
            this.haveSwitch = true;

            Destroy(this.collider);
        }

        if (collision.gameObject.CompareTag("PlayerSize"))
        {
            for (int i = 0; i < this.shattedModel.transform.childCount; i++)
            {
                Transform subChild = this.shattedModel.transform.GetChild(i);
                subChild.GetComponent<Chunk>().Explose(collision.GetContact(0).point, this.playerExplotionForce, collision.relativeVelocity.magnitude, playerExplotionRadius);
            }
        }
        else if (collision.gameObject.CompareTag("Missile"))
        {
            for (int i = 0; i < this.shattedModel.transform.childCount; i++)
            {
                Transform subChild = this.shattedModel.transform.GetChild(i);
                
                if (collision.gameObject.GetComponent<Rocket>() != null)
                    subChild.GetComponent<Chunk>().Explose(collision.GetContact(0).point, this.playerExplotionForce, collision.relativeVelocity.magnitude, playerExplotionRadius);
                else if (collision.gameObject.GetComponent<ExplosiveRocket>() != null)
                    StartCoroutine(subChild.GetComponent<Chunk>().DestroyChunk());
            }
        }
    }
}

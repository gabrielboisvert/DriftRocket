using UnityEngine;
public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float range = 5;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float rotationSpeed = 100;
    [SerializeField] private GameObject pivot;
    [SerializeField] private float angleRangeNeedToShoot = 10;
    [SerializeField] private LayerMask layer;
    private AudioSource src;
    private float fireTimer = 0;
    private Vector3 playerPos;
    bool seeSomething = false;
    [SerializeField] private float detectionFov = 140;
    public float Range { get => range; set => range = value; }
    void Start()
    {
        GetComponent<SphereCollider>().radius = this.Range;
        this.playerPos = this.transform.position;
        this.src = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!this.seeSomething)
            return;

        this.fireTimer += Time.deltaTime;
        this.CheckConeRange();
    }
    private void CheckConeRange()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(this.transform.position, this.range * this.transform.localScale.x, this.layer, QueryTriggerInteraction.Collide);
        if (rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 dir = (target.position - this.transform.position);

            float angle = Vector3.Angle(this.transform.up, dir);
            if ( angle < detectionFov / 2)
            {
                float dist = Vector3.Distance(this.transform.position, target.position);

                if (Physics.Raycast(this.transform.position, dir, dist, this.layer, QueryTriggerInteraction.Collide))
                {
                    Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, this.playerPos - this.transform.position);
                    float oldRot = targetRotation.eulerAngles.z;
                    this.pivot.transform.rotation = Quaternion.RotateTowards(this.pivot.transform.rotation, targetRotation, Time.deltaTime * this.rotationSpeed);

                    if (this.fireTimer >= attackSpeed)
                    {
                        float zDiff = oldRot - this.pivot.transform.rotation.eulerAngles.z;
                        if (-this.angleRangeNeedToShoot <= zDiff && zDiff <= this.angleRangeNeedToShoot)
                        {
                            this.fireTimer = 0;
                            this.Fire();
                        }
                    }
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
         //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
         Gizmos.DrawWireSphere(transform.position, this.range * this.transform.localScale.x);
        }
    private void Fire()
    {
        this.src.PlayOneShot(this.src.clip);
        Instantiate(this.bullet, this.pivot.transform.GetChild(0).position, this.pivot.transform.rotation);
    }
    private void OnTriggerStay(Collider other)
    {
        this.playerPos = other.gameObject.transform.position;
        this.seeSomething = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.seeSomething = false;
    }
}

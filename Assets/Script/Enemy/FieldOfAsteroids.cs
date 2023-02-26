using System.Collections;
using UnityEngine;
public class FieldOfAsteroids : MonoBehaviour
{
    private Rigidbody body;
    public void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            for (int i = 0; i < this.transform.childCount; i++)
                this.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
    }
}

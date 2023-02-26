using UnityEngine;
public class LavaIncreaseTrigger : MonoBehaviour
{
    [SerializeField] private float increase = 10;
    [SerializeField] private Lava lava;

    public void OnTriggerEnter(Collider other)
    {
        this.lava.Speed += this.increase;
        StartCoroutine(GameManager.Ui.StartWarning());
        GetComponent<Collider>().enabled = false;
    }
}
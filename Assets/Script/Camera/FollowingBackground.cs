using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBackground : MonoBehaviour
{
    [SerializeField] private float parralaxSpeed = 2f;
    [SerializeField] private GameObject player;
    private Material mat;
    private float oldZ;

    // Start is called before the first frame update
    void Start()
    {
        this.mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset = new Vector2(this.player.transform.position.x / this.transform.localScale.x / this.parralaxSpeed, this.player.transform.position.y / this.transform.localScale.y / this.parralaxSpeed);
    }
}

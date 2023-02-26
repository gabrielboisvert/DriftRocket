using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnimation : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float radius = 2;
    private Vector3 initPos;
    private float timer = 0;
    void Start()
    {
        this.initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime * this.speed;

        float x = (Mathf.Cos(this.timer) * this.radius) + this.initPos.x;
        float y = (Mathf.Sin(this.timer) * this.radius) + this.initPos.y;

        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }
}

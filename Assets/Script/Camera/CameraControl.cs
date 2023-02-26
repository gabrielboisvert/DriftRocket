using System;
using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float playerHeight;
    [SerializeField] private Vector3 edgeDetectorSize;
    [SerializeField] private float playerZoom = -20;
    [SerializeField] private float playerZoomOutTime = 0.5f;
    private bool finishZoomOut = false;
    private bool stopFollowing = false;
    private float zAway;

    private BoxCollider collider;
    private bool canMoveX;
    private float oldX;
    private bool canMoveY;
    private float oldY;
    public Vector3 EdgeDetectorSize { get => edgeDetectorSize; set => edgeDetectorSize = value; }
    void Start()
    {
        this.zAway = this.transform.position.z;
        this.playerHeight = GameManager.Player.GetComponent<Collider>().bounds.size.y * 3;

        this.collider = this.gameObject.AddComponent<BoxCollider>();
        this.collider.isTrigger = true;
        this.collider.size = this.edgeDetectorSize;
        this.collider.center = new Vector3(GameManager.Player.transform.position.x, GameManager.Player.transform.position.y, -this.zAway);

        this.canMoveX = true;
        this.canMoveY = true;

        this.transform.position = new Vector3(GameManager.Player.transform.position.x, GameManager.Player.transform.position.y, this.playerZoom);

        GameManager.Player.OnReady += new EventHandler(delegate (System.Object o, EventArgs a) { StartCoroutine(this.ZoomOut()); });
        GameManager.Player.OnFinish += new EventHandler(delegate (System.Object o, EventArgs a) { this.stopFollowing = true; });
    }
    void Update()
    {
        if (this.finishZoomOut)
            this.ChangeCameraPos();
    }
    public IEnumerator ZoomOut()
    {
        float elapse = 0;
        float currentY = GameManager.Player.transform.position.y;
        while (elapse < this.playerZoomOutTime)
        {
            float yInterpolate = Mathf.Lerp(currentY, GameManager.Player.transform.position.y + this.playerHeight, elapse / this.playerZoomOutTime);
            float zInterpolate = Mathf.Lerp(this.playerZoom, this.zAway, elapse / this.playerZoomOutTime);
            // Camera position
            Vector3 newPos = new Vector3(GameManager.Player.transform.position.x, yInterpolate, zInterpolate);
            this.transform.position = newPos;

            // collider box
            float x = -(this.transform.position.x - GameManager.Player.transform.position.x);
            float y = -(this.transform.position.y - GameManager.Player.transform.position.y);
            this.collider.center = new Vector3(x, y, -newPos.z);

            elapse += Time.deltaTime;
            yield return null;
        }
        this.finishZoomOut = true;
    }
    private void ChangeCameraPos()
    {
        // Camera position
        Vector3 newPos = new Vector3(this.oldX, this.oldY, this.zAway);
        if (this.canMoveY)
            newPos.y = this.oldY = GameManager.Player.transform.position.y + this.playerHeight;
        if (this.canMoveX && !this.stopFollowing)
            newPos.x = this.oldX = GameManager.Player.transform.position.x;
        this.transform.position = newPos;

        // collider box
        float x = -(this.transform.position.x - GameManager.Player.transform.position.x);
        float y = -(this.transform.position.y - GameManager.Player.transform.position.y);
        this.collider.center = new Vector3(x, y, -this.zAway);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Top"))
            this.canMoveY = false;
        else if (other.gameObject.CompareTag("Edge"))
            this.canMoveX = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Top"))
            this.canMoveY = true;
        else if (other.gameObject.CompareTag("Edge"))
            this.canMoveX = true;
    }
}
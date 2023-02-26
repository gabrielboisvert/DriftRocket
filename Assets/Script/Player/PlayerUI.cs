using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private RectTransform uI;
    [SerializeField] private Vector3 fallingDetectorSize;
    [SerializeField] private CameraControl cam;
    [SerializeField] private GameObject indicator;
    [SerializeField] private float uIWaringDuration = 2;
    [SerializeField] private float uIWaringRestTime = 0.25f;
    [SerializeField] private TextMeshProUGUI timerUI;
    private AudioSource src;
    private bool hasStart = false;
    private float timer;
    private Vector3 initialScale;

    private float upDist;
    private Vector2 uiOffset;
    struct FallingObject
    {
        public GameObject objID;
        public GameObject indicator;
        public RectTransform transform;
        public FallingObject(GameObject a, GameObject b, RectTransform c)
        {
            this.objID = a;
            this.indicator = b;
            this.transform = c;
        }
    }
    public enum PowerUPName {PowerUPBoost, PowerUPShield, PowerUPMissile};
    private List<FallingObject> detectedFallingObject;
    public CameraControl Cam { get => cam; set => cam = value; }
    public Vector3 FallingDetectorSize { get => fallingDetectorSize; set => fallingDetectorSize = value; }
    void Start()
    {
        this.upDist = Cam.EdgeDetectorSize.y * 0.75f;
        this.detectedFallingObject = new List<FallingObject>();
        this.uiOffset = new Vector2(uI.sizeDelta.x / 2f, uI.sizeDelta.y / 2f);
        this.initialScale = this.indicator.transform.localScale;

        GameManager.Ui = this;
        this.src = this.uI.GetComponent<AudioSource>();

        GameManager.Player.OnReady += new EventHandler(delegate (System.Object o, EventArgs a) 
        { 
            this.timer = Time.time * 1000; this.hasStart = true; });
        GameManager.Player.OnFinish += new EventHandler(delegate (System.Object o, EventArgs a) { this.hasStart = false; });
    }

    void Update()
    {
        this.CheckFallingObstacle();
        if (this.hasStart)
            this.UpdateTimer();
    }
    private void CheckFallingObstacle()
    {
        //Remove too hight element
        for (int i = 0; i < this.detectedFallingObject.Count; i++)
        {
            if (this.detectedFallingObject[i].objID == null)
            {
                Destroy(this.detectedFallingObject[i].indicator.gameObject);
                this.detectedFallingObject.RemoveAt(i);
                i--;
                continue;
            }

            float dist = (this.detectedFallingObject[i].objID.transform.position.y - this.transform.position.y);
            if (dist > this.fallingDetectorSize.y * 0.5)
            {
                Destroy(this.detectedFallingObject[i].indicator.gameObject);
                this.detectedFallingObject.RemoveAt(i);
                i--;
            }
        }

        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, FallingDetectorSize * 0.5f, Quaternion.identity, 1 << 10);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject obj = hitColliders[i].gameObject;

            float dist = (obj.transform.position.y - this.transform.position.y);
            if (dist < 0)
                continue;

            if (dist > this.upDist)
            {
                if (!this.detectedFallingObject.Exists(x => x.objID == obj))
                {
                    GameObject clone = Instantiate(this.indicator, Vector3.zero, Quaternion.identity);
                    RectTransform rectT = clone.GetComponent<RectTransform>();
                    clone.transform.SetParent(this.uI.transform.Find("Warning"), false);
                    rectT.localPosition = this.indicator.transform.localPosition;
                    rectT.localScale = Vector3.Lerp(this.initialScale * 0.5f, this.initialScale * 2, this.upDist / dist);
                    this.detectedFallingObject.Add(new FallingObject(obj, clone, rectT));

                    Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(obj.transform.position);
                    Vector2 proportionalPosition = new Vector2(ViewportPosition.x * this.uI.sizeDelta.x, ViewportPosition.y * this.uI.sizeDelta.y);
                    rectT.localPosition = new Vector3(proportionalPosition.x - uiOffset.x, rectT.localPosition.y, rectT.localPosition.z);
                }
                else
                {
                    RectTransform indic = this.detectedFallingObject.Find(x => x.objID == obj).transform;
                    indic.localScale = Vector3.Lerp(this.initialScale * 0.25f, this.initialScale * 2, this.upDist / dist);

                    Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(obj.transform.position);
                    Vector2 proportionalPosition = new Vector2(ViewportPosition.x * this.uI.sizeDelta.x, ViewportPosition.y * this.uI.sizeDelta.y);
                    indic.localPosition = new Vector3(proportionalPosition.x - uiOffset.x, indic.localPosition.y, indic.localPosition.z);
                }
            }
            else
            {
                try
                {
                    FallingObject indic = this.detectedFallingObject.Find(x => x.objID == obj);
                    Destroy(indic.indicator.gameObject);
                    this.detectedFallingObject.Remove(indic);
                }
                catch (NullReferenceException)
                { }
            }
        }
    }
    public void AddStar()
    {
        foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarUI"))
        {
            RawImage img = star.GetComponent<RawImage>();
            Texture2D[] textures = star.GetComponent<TextureArray>().Textures;
            if (img.texture == textures[0])
            {
                img.texture = textures[1];
                return;
            }
        }
    }
    public void SwitchPowerUP(PowerUPName name)
    {
        Transform obj = null;
        switch (name)
        {
            case PowerUPName.PowerUPBoost:
                obj = this.uI.Find("PowerUpUI").Find("BoostUI").transform;
                break;
            case PowerUPName.PowerUPMissile:
                obj = this.uI.Find("PowerUpUI").Find("MissileUI").transform;
                break;
            case PowerUPName.PowerUPShield:
                obj = this.uI.Find("PowerUpUI").Find("ShieldUI").transform;
                break;
        }

        if (obj == null)
            return;

        obj.GetComponent<PowerUpUI>().SwitchTexture();
    }
    public IEnumerator StartWarning()
    {
        this.src.Play();
        GameObject parent = this.uI.Find("Warning").gameObject;

        GameObject right = parent.transform.GetChild(0).gameObject;
        GameObject left = parent.transform.GetChild(1).gameObject;
        bool showing = false;
        float elapse = 0;
        while (elapse < this.uIWaringDuration)
        {
            showing = !showing;
            right.SetActive(showing);
            left.SetActive(showing);

            elapse += Time.deltaTime + this.uIWaringRestTime;
            yield return new WaitForSeconds(this.uIWaringRestTime);
        }

        right.SetActive(false);
        left.SetActive(false);
        this.src.Stop();
    }
    public void UpdateTimer()
    {
        this.timerUI.text = TimeSpan.FromMilliseconds((Time.time * 1000) - this.timer).ToString(@"m\:ss\:ff");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateController : MonoBehaviour
{
    void Start()
    {
        //Init controller ps4 or ps5
        StartCoroutine(DSController.InitController());
    }
}

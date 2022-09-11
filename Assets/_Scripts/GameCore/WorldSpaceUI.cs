using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUI : MonoBehaviour
{
    private Camera mainCam;
    void Start()
    {
        mainCam = CameraManager.Instance.Camera;
        GetComponent<Canvas>().worldCamera = mainCam;
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCam.transform);
    }
}

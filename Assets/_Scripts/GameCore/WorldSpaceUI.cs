using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUI : MonoBehaviour
{
    private CameraService _cameraService;
    
    void Start()
    {
        _cameraService = ServiceLocator.Instance.Get<CameraService>();
        GetComponent<Canvas>().worldCamera = _cameraService.Camera;
    }

    private void LateUpdate()
    {
        transform.LookAt(_cameraService.Camera.transform);
    }
}

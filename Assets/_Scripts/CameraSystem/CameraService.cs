using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CameraService : Service<CameraService>
{
    [SerializeField] private Camera camera;
    public Camera Camera => camera;

    internal override void Init()
    {
    }

    internal override void Begin()
    {
        SetReady();
    }

    internal override void Dispose()
    {
    }
}

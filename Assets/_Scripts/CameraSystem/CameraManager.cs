using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CameraManager : AutoSingleton<CameraManager>
{
    public Camera Camera { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Camera = GetComponent<Camera>();
    }
}

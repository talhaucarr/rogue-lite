using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using JetBrains.Annotations;
using UnityEngine;

public class NetworkService : Service<NetworkService>
{
    private NetworkStateChangeEvent _networkStateChangeEvent;

    private NetworkReachability _current;

    internal override void Init()
    {
        _networkStateChangeEvent = _serviceProvider.Get<NetworkStateChangeEvent>();
        _current = Application.internetReachability;
        
#if UNITY_EDITOR
        if (PlayerPrefs.HasKey("ForceDisconnect"))
        {
            _forced = true;
            _current = NetworkReachability.NotReachable;
            PlayerPrefs.DeleteKey("ForceDisconnect");
        }
#endif
    }

    internal override void Begin()
    {
        SetReady();
    }

    public bool HasNetwork()
    {
        return _current != NetworkReachability.NotReachable;
    }

    public NetworkReachability GetNetworkStatus()
    {
        return _current;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad1))
        {
            Disconnect();
        }
        
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Keypad2))
        {
            ResetConnection();
        }
        
        if(_forced) return;
#endif
        
        if (_current != Application.internetReachability)
        {
            _current = Application.internetReachability;
            _networkStateChangeEvent.Fire(_current);
        }
    }
    
#if UNITY_EDITOR
    private bool _forced;
    
    [UsedImplicitly]
    [Button]
    public void Disconnect()
    {
        _forced = true;
        _current = NetworkReachability.NotReachable;
        _networkStateChangeEvent.Fire(_current);
        Debug.LogWarning("Disconnected");
    }

    [UsedImplicitly]
    [Button]
    public void ResetConnection()
    {
        _forced = false;
        Debug.LogWarning("Connection reset");
    }
#endif
}

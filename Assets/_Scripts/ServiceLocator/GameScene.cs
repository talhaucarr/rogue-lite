using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private SceneReadyEvent _sceneReadyEvent;
    private LoadingService _loadingService;
    
    void Awake()
    {
        _sceneReadyEvent = ServiceProvider.Instance.Get<SceneReadyEvent>();
        _loadingService = ServiceProvider.Instance.Get<LoadingService>();
        
        _sceneReadyEvent.Subscribe(OnSceneReady);
    }

    private void OnSceneReady(Scene scene)
    {
        if(!scene.name.Equals(gameObject.scene.name))
            return;
        _loadingService.HideLoading();
    }

    private void OnDestroy()
    {
        _sceneReadyEvent.UnSubscribe(OnSceneReady);
    }
}

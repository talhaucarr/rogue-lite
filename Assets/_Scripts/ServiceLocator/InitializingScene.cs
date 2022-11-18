using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializingScene : MonoBehaviour
{
    public static InitializingScene Instance;

    private ServiceProvider _serviceProvider;
    private SceneReadyEvent _sceneReadyEvent;

    private void Awake()
    {
        Instance = this;
        _serviceProvider = ServiceProvider.Instance;
        _sceneReadyEvent = _serviceProvider.Get<SceneReadyEvent>();
        _sceneReadyEvent.Subscribe(OnSceneReady);
    }

    private void OnSceneReady(Scene scene)
    {
        if(scene == gameObject.scene && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadSceneAsync(SceneLoadService.GameScene, LoadSceneMode.Additive).completed += a =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneLoadService.GameScene));
                _serviceProvider.Resolve();
            };
        }
    }

    private void Start()
    {
        _serviceProvider.Resolve();
    }

    private void OnDestroy()
    {
        _sceneReadyEvent.UnSubscribe(OnSceneReady);
    }
}

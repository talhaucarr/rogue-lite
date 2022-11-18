using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EasyButtons;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadService : SceneService<SceneLoadService>
{
    public const string InitializingScene = "InitializingScene";
    public const string GameScene = "GameScene";
    public const string LoadingScene = "LoadingScene";
    
    [SerializeField]
    List<Service> SceneServices;

    private SceneReadyEvent _sceneReadyEvent;

    internal override void Init()
    {
        _sceneReadyEvent = _serviceProvider.Get<SceneReadyEvent>();
        _dependencies = SceneServices;
    }

    internal override void Begin()
    {
        SetReady();
        _sceneReadyEvent.Fire(gameObject.scene);
    }

#if UNITY_EDITOR
    [Button]
    private void CollectMapServices()
    {
        var list = FindObjectsOfType<Service>().ToList();
        list.Remove(this);
        SceneServices = list;
    }
#endif
}



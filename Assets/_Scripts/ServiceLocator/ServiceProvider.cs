using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyButtons;

[DefaultExecutionOrder(-100_000)]
public class ServiceProvider : MonoBehaviour
{
    private Dictionary<string, Service> _services = new Dictionary<string, Service>();
    
    private List<Service> _dependencyWaitingServices = new List<Service>();
    private Dictionary<string, Service> _newServices = new Dictionary<string, Service>();

    public static ServiceProvider Instance;

    private bool _dependencyDirty;
    private bool _checkingDependencies;
    private bool _quit;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Startup()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != SceneLoadService.InitializingScene)
        {
            Debug.LogWarning("ServiceProvider self start. This feature unity editor only and should't be used in runtime.");
            SceneManager.LoadSceneAsync(SceneLoadService.InitializingScene, LoadSceneMode.Additive).completed += handle =>
            {
                Instance.Get<LoadingService>().ShowLoading();
            };
        }
    }

    [Button]
    public void Resolve()
    {
        foreach (var pair in _newServices)
        {
            pair.Value.Init();
        }
        foreach (var pair in _newServices)
        {
            if (pair.Value.HasDependency())
            {
                _dependencyWaitingServices.Add(pair.Value);
            }
            else
            {
                pair.Value.Begin();
            }
        }
        CheckDependencies();
        _newServices.Clear();
    }

    public T Get<T>(string contextName = "") where T : Service
    {
        TryGet(out T result, contextName);
        return result;
    }

    public bool TryGet<T>(out T result, string contextName = "") where T : Service
    {
        var type = typeof(T);
#if UNITY_EDITOR
        if (typeof(SceneService<T>).IsAssignableFrom(type) && contextName == "")
        {
            Debug.LogWarning($"{type} is sceneService but context is empty. You might need pass a context.");
        }
#endif
        
        string name = type.Name + "_" + contextName;
        if (!_services.ContainsKey(name))
        {
#if UNITY_EDITOR
            Debug.LogWarning("Gameobject reference for service : " + name + "is missing");
#endif
            result = null;
            return false;
        }
        
        result = (T)_services[name];
        return true;
    }

    public void Register(Service service)
    {
        string name = service.GetType().Name + "_" + service.GetContextName();
        _services.Add(name, service);
        _newServices.Add(name, service);
    }

    public void UnRegister(Service service)
    {
        string name = service.GetType().Name + "_" + service.GetContextName();
        _services.Remove(name);
        if (_newServices.ContainsKey(name))
            _newServices.Remove(name);
        if (_dependencyWaitingServices.Contains(service))
            _dependencyWaitingServices.Remove(service);
    }

    public void SetDependencyDirty()
    {
        if (_checkingDependencies)
        {
            _dependencyDirty = true;
        }
        else
        {
            CheckDependencies();
        }
    }

    public void CheckDependencies()
    {
        _checkingDependencies = true;
        for (int i = _dependencyWaitingServices.Count - 1; i >= 0; i--)
        {
            var service = _dependencyWaitingServices[i];
            if (service.IsDependenciesReady())
            {
                _dependencyWaitingServices.Remove(service);
                service.Begin();
            }
        }
        if (_dependencyDirty)
        {
            _dependencyDirty = false;
            CheckDependencies();
        }
        _checkingDependencies = false;
    }

    public int GetNotReadyServiceCount()
    {
        int count = 0;
        foreach (var service in _services)
        {
            if (!service.Value.IsReady())
                count++;
        }
        return count;
    }

    public List<string> GetNotReadyServiceKeys()
    {
        var list = new List<string>();
        foreach (var pair in _services)
        {
            if(pair.Value.IsDependenciesReady() && !pair.Value.IsReady())
                list.Add(pair.Key);
        }
        return list;
    }

    public int GetServiceCount()
    {
        return _services.Count;
    }

    public bool IsQuiting()
    {
        return _quit;
    }

    private void OnApplicationQuit()
    {
        _quit = true;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    [Button()]
    public void DebugDumpServices()
    {
        foreach (var pair in _services)
        {
            Debug.Log($"{pair.Key} -> {pair.Value}");
        }
    }

    [Button]
    public void DebugDumpNotReadyServices()
    {
        foreach (var pair in _services)
        {
            if(pair.Value.IsDependenciesReady() && !pair.Value.IsReady())
                Debug.Log($"{pair.Key} is not ready.");
        }
    }

    [Button]
    public void DebugDumpWaitingServices()
    {
        foreach (var service in _dependencyWaitingServices)
        {
            Debug.Log($"{service.GetType().Name} ->");
            foreach (var depend in service.GetDependencies())
            {
                if (!depend.IsReady())
                    Debug.Log($"{depend.GetType().Name}");
            }
        }
    }
}

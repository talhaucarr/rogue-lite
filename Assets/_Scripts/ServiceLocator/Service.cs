using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-10_000)]
public class Service : MonoBehaviour
{
    protected bool _isReady;
    protected List<Service> _dependencies;
    protected ServiceProvider _serviceProvider;

    protected void Awake()
    {
        _serviceProvider = ServiceProvider.Instance;
        _serviceProvider.Register(this);
    }

    /// <summary>
    /// Called in start of ServiceProvider. Use for get references and dependency declaration.
    /// </summary>
    internal virtual void Init()
    {
    }

    /// <summary>
    /// Called after all dependencies ready. Use for game logic.
    /// </summary>
    internal virtual void Begin()
    {
    }

    /// <summary>
    /// Called before OnDestroy. Use for cleanup. If application quiting this not gonna be called.
    /// </summary>
    internal virtual void Dispose()
    {
    }

    public virtual bool IsReady()
    {
        return _isReady;
    }

    public virtual void SetReady()
    {
        _isReady = true;
        _serviceProvider.SetDependencyDirty();
    }

    public virtual bool IsDependenciesReady()
    {
        if (_dependencies == null)
        {
            return true;
        }
        foreach (var service in _dependencies)
        {
            Debug.Assert(service != null, $"{name} has null dependency.", this);
            if (!service.IsReady())
                return false;
        }
        return true;
    }

    public bool HasDependency()
    {
        return _dependencies != null;
    }

    public List<Service> GetDependencies()
    {
        return _dependencies;
    }

    public virtual string GetContextName()
    {
        return string.Empty;
    }

    private void OnDestroy()
    {
        if (_serviceProvider != null && !_serviceProvider.IsQuiting())
        {
            Dispose();
            _serviceProvider.UnRegister(this);
        }
    }
}

public class Service<T> : Service
{
    
}

public class SceneService<T> : Service<T>
{
    public override string GetContextName()
    {
        return gameObject.scene.name;
    }
}

public class GameObjectService<T> : Service<T>
{
    private new void Awake()
    {
        base.Awake();
        ServiceProvider.Instance.Resolve();
    }
    
    public override string GetContextName()
    {
        var goName = gameObject.name.Replace("(Clone)", "");//in case its instantiated in the same frame
        return "GameObject_" + goName;
    }
}

public class GameObjectEvent<TEventType, TBaseType> : Event<TEventType, TBaseType>
{
    private new void Awake()
    {
        base.Awake();
        ServiceProvider.Instance.Resolve();
    }

    public override string GetContextName()
    {
        var goName = gameObject.name.Replace("(Clone)", "");//incase its instantiated in the same frame
        return "GameObject_" + goName;
    }
}

public class SceneEvent<TEventType, TBaseType> : Event<TEventType, TBaseType>
{
    public override string GetContextName()
    {
        return gameObject.scene.name;
    }
}
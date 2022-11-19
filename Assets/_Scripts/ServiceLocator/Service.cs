using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-10_000)]
public class Service : MonoBehaviour
{
    protected bool _isReady;
    protected List<Service> _dependencies;
    private ServiceLocator _serviceLocator;

    protected void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.Register(this);
    }
    
    internal virtual void Init()
    {
    }
    
    internal virtual void Begin()
    {
    }
    
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
        _serviceLocator.SetDependencyDirty();
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
        if (_serviceLocator != null && !_serviceLocator.IsQuiting())
        {
            Dispose();
            _serviceLocator.UnRegister(this);
        }
    }
}

public abstract class Service<T> : Service
{
    /// <summary>
    /// Called in start of ServiceLocator. Use for get references and dependency declaration.
    /// </summary>
    internal abstract override void Init();

    /// <summary>
    /// Called after all dependencies ready. Use for game logic.
    /// </summary>
    internal abstract override void Begin();

    /// <summary>
    /// Called before OnDestroy. Use for cleanup. If application quiting this not gonna be called.
    /// </summary>
    internal abstract override void Dispose();
}

public abstract class SceneService<T> : Service<T>
{
    public override string GetContextName()
    {
        return gameObject.scene.name;
    }
}
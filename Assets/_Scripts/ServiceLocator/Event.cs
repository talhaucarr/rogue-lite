using UnityEngine;
using UnityEngine.Events;

public class Event<TEventType, TBaseType> : Service<TBaseType>
{
    private ConcreteEvent<TEventType> _event = new ConcreteEvent<TEventType>();

    internal override void Begin()
    {
        SetReady();
    }

    public virtual void Fire(TEventType v1)
    {
#if UNITY_EDITOR
        Debug.Log($"Event [{GetType().Name}] - Data [{v1.ToString()}]" );
#endif
        _event.Invoke(v1);
    }

    public void Subscribe(UnityAction<TEventType> listener)
    {
        _event.AddListener(listener);
    }

    public void UnSubscribe(UnityAction<TEventType> listener)
    {
        _event.RemoveListener(listener);
    }
}

public class ConcreteEvent<T> : UnityEvent<T>
{

}

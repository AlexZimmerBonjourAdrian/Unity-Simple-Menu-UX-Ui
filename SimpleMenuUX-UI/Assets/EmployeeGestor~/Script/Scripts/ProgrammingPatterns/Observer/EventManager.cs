using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("EventManager");
                return obj.AddComponent<EventManager>();
            }

            return _inst;
        }
    }

    private static EventManager _inst;

    void Awake()
    {
        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _inst = this;


    }

    public event Action OnNotificationSuccesfull;

    public event Action OnNotificationError;

    public event Action OnActiveMenu;

    public event Action OnDesactiveMenu;

    public event Action OnActiveDataMenu;

    public event Action OnDesactiveDataMenu;


  
    public void ActiveDataMenu()
    {
        OnActiveDataMenu?.Invoke();
    }

    public void DesactiveDataMenu()
    {
        OnDesactiveDataMenu?.Invoke();
    }

    public void ActiveMenu()
    {
        OnActiveMenu?.Invoke();
    }

    public void DesactiveMenu()
    {
        OnDesactiveMenu?.Invoke();
    }

    public void NotificationSuccesfull()
    {
        OnNotificationSuccesfull?.Invoke();
    }

    public void NotificationError()
    {
        OnNotificationError?.Invoke();
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    Dictionary<Type, Action<Events.BaseEvent>> eventActions;
    

    public override void InitSingleton()
    {
        eventActions = new Dictionary<Type, Action<Events.BaseEvent>>();
        // New events have to be added here to be recognised!!!!
        eventActions[typeof(Events.ExampleEvent)] = null;
    }
    

    public static void AddEventListener<Event>(Action<Events.BaseEvent> _listener) where Event : Events.BaseEvent
    {
        instance.eventActions[typeof(Event)] += _listener;
    }


    public static void RemoveEventListener<Event>(Action<Events.BaseEvent> _listener) where Event : Events.BaseEvent
    {
        instance.eventActions[typeof(Event)] -= _listener;
    }


    public static void TriggerEvent<Event>(Event _event) where Event : Events.BaseEvent
    {
        instance.eventActions[typeof(Event)]?.Invoke(_event);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleListener : MonoBehaviour
{
    // This is an example of how to react to an event being triggered
    // You can trigger an event from any script with e.g. EventManager.TriggerEvent(new Events.ExampleEvent(1))

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddEventListener<Events.ExampleEvent>(HandleEvent_ExampleEvent);
    }

    // Update is called once per frame
    void Update()
    {
        EventManager.RemoveEventListener<Events.ExampleEvent>(HandleEvent_ExampleEvent);
    }

    void HandleEvent_ExampleEvent(Events.BaseEvent _baseEvent)
    {
        // Cast from base to derived (terrible idea) because I was too lazy to design something that doesn't need you to do this :)
        Events.ExampleEvent exampleEvent = _baseEvent as Events.ExampleEvent;

        // Do something here
    }
}

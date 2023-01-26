using System;
using UnityEngine;
using UnityEngine.Events;

public class CollBehavior : MonoBehaviour
{
    public UnityEvent triggerStartEvent, triggerEndEvent,collisionEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerStartEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerEndEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionEvent.Invoke();
    }
}

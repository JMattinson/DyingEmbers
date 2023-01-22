using UnityEngine;
using UnityEngine.Events;

public class CollBehavior : MonoBehaviour
{
    public UnityEvent collisionStartEvent, collisionEndEvent;

    private void OnTriggerEnter(Collider other)
    {
        collisionStartEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        collisionEndEvent.Invoke();
    }
}

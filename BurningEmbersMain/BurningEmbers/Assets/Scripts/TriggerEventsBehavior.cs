using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerEventsBehavior : MonoBehaviour
{
    public UnityEvent triggerEnterEvent;
    
    private Collider colliderObj;
    // Start is called before the first frame update
    private void Start()
    {
        colliderObj = GetComponent<Collider>();
        colliderObj.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }
}


using UnityEngine;
using UnityEngine.Events;

public class StartAction : MonoBehaviour
{
    public UnityEvent startEvent;
    // Start is called before the first frame update
    void Start()
    {
        startEvent.Invoke();
    }

}

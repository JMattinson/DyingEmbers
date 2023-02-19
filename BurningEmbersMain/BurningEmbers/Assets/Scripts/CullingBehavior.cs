using System;
using UnityEngine;
using UnityEngine.Events;

public class CullingBehavior : MonoBehaviour
{
    public UnityEvent cullInEvent, cullOutEvent;
    void OnBecameVisible()
    {
        print("Visible");
        cullInEvent.Invoke();
    }
}

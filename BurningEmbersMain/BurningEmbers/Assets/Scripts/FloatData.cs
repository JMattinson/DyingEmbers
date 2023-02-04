//This code enables the creation of Float files
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
  
    public float value;
    public UnityEvent onMinEvent;

    public void SetValue(float num)
    {
        value = num;
    }
    public void UpdateValue(float num)
    {
    
        value += num;
        
    }

    public void CheckMin(float num)
    {
        if (value <= num)
        {
            value = num;
            onMinEvent.Invoke();
        }
    }

    public void CheckMax(float num)
    {
        if (value >= num)
        {
            value = num;
        }
    }
    
}
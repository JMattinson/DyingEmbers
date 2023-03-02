using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class BurnObjectBase : MonoBehaviour,IBurning,IBurnUp,IStopBurning
{
    private float currentHp;
    public UnityEvent BurningEvent,stopBurningEvent,burnUpEvent;
    public FloatData pickupMaxHp;
    public IntData pickupCurrentDamage;
    
    

    private void Start()
    {
        currentHp = pickupMaxHp.value;
    }


   

    public void Burning()
    {
        BurningEvent.Invoke();
        currentHp -= pickupCurrentDamage.value;
        if (currentHp <= 0)
        {
            BurnUp();
        }    
    }

    public void BurnUp()
    {
        print("Burn Up!");
        burnUpEvent.Invoke();
    }

    public void StopBurning()
    {
        stopBurningEvent.Invoke();
        currentHp += pickupMaxHp.value;
        
    }
    
}

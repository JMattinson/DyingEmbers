
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class FuelPickupBase : MonoBehaviour,IBurning,IBurnUp,IStopBurning
{
    private int currentHp;
    public UnityEvent stopBurningEvent,burnUpEvent;
    public IntData pickupMaxHp;
    public IntData pickupCurrentDamage;

    private void Start()
    {
        currentHp = pickupMaxHp.value;
    }


   

    public void Burning()
    {
        currentHp -= pickupCurrentDamage.value;
        print(currentHp);
        if (currentHp <= 0)
        {
            BurnUp();
        }    
    }

    public void BurnUp()
    {
        burnUpEvent.Invoke();
    }

    public void StopBurning()
    {
        stopBurningEvent.Invoke();
    }
}

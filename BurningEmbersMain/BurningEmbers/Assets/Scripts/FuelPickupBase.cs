
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class FuelPickupBase : MonoBehaviour,IBurning,IBurnUp,IStopBurning
{
    private int currentHealth;
    public UnityEvent pickupEvent, burningEvent,stopBurningEvent,burnUpEvent;
    public IntData pickupMaxHp;
    public IntData pickupCurrentDamage;

    private void Start()
    {
        currentHealth = pickupMaxHp.value;
    }


   

    public void Burning()
    {
        throw new NotImplementedException();
    }

    public void BurnUp()
    {
        throw new NotImplementedException();
    }

    public void StopBurning()
    {
        throw new NotImplementedException();
    }
}

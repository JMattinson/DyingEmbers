using System;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeBehavior : MonoBehaviour
{
    public FloatListData floatUpgradePath;
    public IntListData intUpgradePath;

    public FloatData floatUpNum;
    public IntData intUpNum;
    public IntData Level;
    

    public IntData currentCash, price;

    private bool canAffordUp;

    public UnityEvent canAffordEvent, cannotAffordEvent,maxoutEvent;

    public void canPlayerAffordFloat()
    {
        canAffordUp = (currentCash.value >= price.value);
        

        if (canAffordUp)
        {
            Level.value++;
            MaxoutCheckFloat();

            currentCash.value -= price.value; 
            floatUpNum.value = floatUpgradePath.floatList[(Level.value)];
            canAffordEvent.Invoke();

            print("level"+ (Level.value +1 ) + ":" + floatUpNum.value);
            MaxoutCheckFloat();
            
            
        }
        else
        {
            cannotAffordEvent.Invoke();
        }

    }
    public void canPlayerAffordint()
    {
        canAffordUp = (currentCash.value >= price.value);
        

        if (canAffordUp)
        {
            Level.value++;
            MaxoutCheckInt();

            currentCash.value -= price.value; 
            intUpNum.value = intUpgradePath.intList[(Level.value)];
            canAffordEvent.Invoke();

            print("level"+ (Level.value +1 ) + ":" + intUpNum.value);
            MaxoutCheckInt();
            
            
        }
        else
        {
            cannotAffordEvent.Invoke();
        }

    }

    public void MaxoutCheckInt()
    {
        if (Level.value + 1 > intUpgradePath.intList.Count - 1)
            maxoutEvent.Invoke();
    }
    public void MaxoutCheckFloat()
    {
        if (Level.value + 1 > floatUpgradePath.floatList.Count - 1)
            maxoutEvent.Invoke();
    }


}

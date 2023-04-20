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
        print(canAffordUp);

        if (canAffordUp)
        {
            currentCash.value -= price.value; 
            
            floatUpNum.value = floatUpgradePath.floatList[Level.value];
            canAffordEvent.Invoke();
            
            Level.value++;
            MaxoutCheck();
            
            print("level"+ Level.value + ":" + floatUpNum.value);
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
            MaxoutCheck();

            currentCash.value -= price.value; 
            intUpNum.value = intUpgradePath.intList[(Level.value)];
            canAffordEvent.Invoke();

            print("level"+ (Level.value +1 ) + ":" + intUpNum.value);
            MaxoutCheck();
            
            
        }
        else
        {
            cannotAffordEvent.Invoke();
        }

    }
    public void MaxoutCheck()
    {
        if(Level.value +1 > intUpgradePath.intList.Count-1)
            maxoutEvent.Invoke();
    }
    
}

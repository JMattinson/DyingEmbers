using UnityEngine;
using UnityEngine.Events;

public class UpgradeBehavior : MonoBehaviour
{
    public FloatListData floatUpgradePath;
    public IntListData intUpgradePath;

    public FloatData floatUpNum;
    public IntData intUpNum;
    

    public IntData currentCash, price;

    private bool canAffordUp;

    public UnityEvent canAffordEvent, cannotAffordEvent;

    public void canPlayerAffordFloat()
    {
        canAffordUp = (currentCash.value >= price.value);
        print(canAffordUp);

        if (canAffordUp)
        {
            currentCash.value -= price.value; 
            floatUpNum.value = floatUpgradePath.floatList[1];
            canAffordEvent.Invoke();
            
        }
        else
        {
            cannotAffordEvent.Invoke();
        }

    }
    public void canPlayerAffordint()
    {
        canAffordUp = (currentCash.value >= price.value);
        print(canAffordUp);

        if (canAffordUp)
        {
            currentCash.value -= price.value; 
            intUpNum.value = intUpgradePath.intList[1];
            canAffordEvent.Invoke();
            
        }
        else
        {
            cannotAffordEvent.Invoke();
        }

    }
    
}

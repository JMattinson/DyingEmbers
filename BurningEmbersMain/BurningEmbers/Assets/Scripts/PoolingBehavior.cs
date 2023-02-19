using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBehavior : MonoBehaviour
{

    public List<Transform> poolList;
    public float seconds = 2f;
    private WaitForSeconds wfsObj;
    private int i;
    public bool canRun = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
      
        wfsObj = new WaitForSeconds(seconds);
        while (canRun)
        {
            
            yield return wfsObj;
            poolList[i].position = Vector3.zero;
            i++;
            if (i> poolList.Count-1)
            {
                i = 0;
            
            }
           
            
        }
        
    }
     
}

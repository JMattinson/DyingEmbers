using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class PoolingBehavior : MonoBehaviour
{

    public List<Transform> poolList;
    
    public float seconds = 2f;
    private WaitForSeconds wfsObj;
    private int i;
    private int last;
    public bool canRun = true;
    public GameObject spawnpoint;

    /*
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
        */
    
    public void PoolSpawn()
    {
        poolList[i].position = spawnpoint.transform.position;
        poolList[i].gameObject.SetActive(true);
        i++;
        if (i> poolList.Count-1)
        {
            i = 0;
            
        } 
    }

    public void PoolDespawn()
    {
        if (i == 0)
        {
            last = poolList.Count-1;
            
        }
        else
        {
            last = (i - 1);
        }
        
        poolList[last].gameObject.SetActive(false);
        poolList[i].position = spawnpoint.transform.position;

        
    }
     
}

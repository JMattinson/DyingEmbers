using System.Collections;

using UnityEngine;

public class DestroyBehavior : MonoBehaviour
{
    public float seconds = 1;
    private WaitForSeconds wfsObj;
    public BoolData stopCheck;


    IEnumerator Start()
    {

        wfsObj = new WaitForSeconds(seconds);
        yield return wfsObj;
        Destroy(gameObject);
        
    }

    public void DestNow()
    {
        Destroy(gameObject);
    }
}

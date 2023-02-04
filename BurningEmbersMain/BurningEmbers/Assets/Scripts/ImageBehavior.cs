using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBehavior : MonoBehaviour
{
    public UnityEvent startEvent;

    private Image imageObj;
    
    // Start is called before the first frame update
    void Start()
    {
        imageObj = GetComponent<Image>();
        startEvent.Invoke();
    }

    // Update is called once per frame
    public void UpdateImage(FloatData data)
    {
        
    }
}

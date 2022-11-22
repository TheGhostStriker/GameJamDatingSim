using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenPhoneInAndOut : MonoBehaviour
{
    public bool phoneOpen = false;
    public LeanTweenType inTweenType;
    public LeanTweenType outTweenType;
    
    // Update is called once per frame
    void Update()
    {

        
        
        
       
    }
    


    void TogglePhone()
    {
        
        phoneOpen = !phoneOpen;

        if(phoneOpen)
        {
            LeanTween.moveLocal(gameObject, new Vector3(290, -170, 0), 1f).setEase(inTweenType);

        }
        else
        {
            LeanTween.moveLocal(gameObject, new Vector3(290, -280, 0), 1f).setEase(outTweenType);
            
        }
    }

    public void OnButtonPressed()
    {
        LeanTween.moveLocal(gameObject, new Vector3(290, -170, 0), 1f).setEase(inTweenType);
    }

    public void OnButtonClose()
    {
        LeanTween.moveLocal(gameObject, new Vector3(290, -280, 0), 1f).setEase(outTweenType);
    }
    
}

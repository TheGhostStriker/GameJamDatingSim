using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPhoneInAndOut : MonoBehaviour
{
    public bool phoneOpen = false;
    public LeanTweenType inTweenType;
    public LeanTweenType outTweenType;
    public float textTimer = 10;
    // Update is called once per frame
    void Update()
    {

        textTimer = textTimer - Time.deltaTime;
        if (textTimer <= 0)
        {
            TogglePhone();
            textTimer = 10;
        }
        
        
       
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
            textTimer = 10f;
        }
    }
    
}

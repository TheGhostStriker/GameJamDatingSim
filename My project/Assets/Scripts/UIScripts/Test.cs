using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    bool phoneOpen = false;
    public LeanTweenType inTweenType;
    public LeanTweenType outTweenType;

    public float phoneTimer = 10;

    // Update is called once per frame
    void Update()
    {
        phoneTimer = phoneTimer - Time.deltaTime;

        if( phoneTimer <= 0)
        {
            phoneTimer = 10;
        }
    }


    void TogglePhone()
    {
        phoneOpen = !phoneOpen;

        if (phoneOpen) LeanTween.moveLocal(gameObject, new Vector3(0, 0, 0), 1f).setEase(inTweenType);
        else LeanTween.moveLocal(gameObject, new Vector3(0, 0, 0), 1f).setEase(outTweenType);
    }

   
}

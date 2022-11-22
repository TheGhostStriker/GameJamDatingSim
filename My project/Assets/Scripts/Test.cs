using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    bool phoneOpen = false;
    public LeanTweenType type;

    // Update is called once per frame
    void Update()
    {
        
    }


    void TogglePhone()
    {
        phoneOpen = !phoneOpen;

        if (phoneOpen) LeanTween.moveLocal(gameObject, new Vector3(0, 0, 0), 1f);
        else LeanTween.moveLocal(gameObject, new Vector3(0, 0, 0), 1f).setOnComplete(spin).setEase(type);
    }

    void spin()
    {

    }
}

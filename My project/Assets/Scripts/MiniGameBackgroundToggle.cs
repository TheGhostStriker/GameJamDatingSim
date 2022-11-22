using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBackgroundToggle : MonoBehaviour
{
    bool backgroundToggled = false;

    public void ToggleBackground()
    {
        backgroundToggled = !backgroundToggled;

        if (backgroundToggled) LeanTween.scale(gameObject, Vector3.one, 0.3f).setEase(LeanTweenType.easeInOutQuad);
        else LeanTween.scale(gameObject, Vector3.zero, 0.3f).setEase(LeanTweenType.easeInOutQuad);
    }
}

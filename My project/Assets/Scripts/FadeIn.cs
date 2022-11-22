using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeIn : MonoBehaviour
{
    WaitForEndOfFrame wait = new WaitForEndOfFrame();
    [SerializeField] UnityEvent afterFadeIn;
    Image fader;
    [SerializeField] float speed;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        fader = GetComponent<Image>();
        Color col = fader.color;
        while (col.a > 0)
        {
            col.a -= Time.deltaTime * speed;
            fader.color = col;
            yield return wait;
        }
        if (afterFadeIn != null) afterFadeIn.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComedyTextPopup : MonoBehaviour
{
    readonly WaitForEndOfFrame wait = new WaitForEndOfFrame();
    SpriteRenderer sr;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Color col = sr.color;
        while (col.a > 0)
        {
            col.a -= Time.deltaTime;
            sr.color = col;
            yield return wait;
        }
        Destroy(gameObject);
    }
}

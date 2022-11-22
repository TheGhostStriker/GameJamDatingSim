using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{

    WaitForEndOfFrame wait = new WaitForEndOfFrame();
    Image fader;
    [SerializeField] float speed;

    public void StartFadeOut()
    {
        fader = GetComponent<Image>();
        StartCoroutine(FadeOut());

        IEnumerator FadeOut()
        {
            Color col = fader.color;
            while (col.a < 1)
            {
                col.a += Time.deltaTime * speed;
                fader.color = col;
                yield return wait;
            }
            SceneManager.LoadScene("Blake - Hub");
        }
    }


}

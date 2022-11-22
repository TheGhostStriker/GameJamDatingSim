using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBounceTween : MonoBehaviour
{
    [SerializeField] Vector3 rotateAxis;
    [SerializeField] float amount;
    [SerializeField] float time;

    private void Start()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -amount));

        LeanTween.rotateAroundLocal(gameObject, rotateAxis, amount * 2f, time).setLoopPingPong().setEase(LeanTweenType.easeInOutQuad);
    }
}

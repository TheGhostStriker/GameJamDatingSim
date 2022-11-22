using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixScript : MonoBehaviour
{
    public RectTransform test;

    private void Update()
    {
        test.position = new Vector3(-821f, -21.87f, 0);
        test.sizeDelta = new Vector2(1220, 200);
    }
}

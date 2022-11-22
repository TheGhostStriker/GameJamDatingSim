using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMessage : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void Initiate(string textString)
    {
        text.text = textString;
    }
}

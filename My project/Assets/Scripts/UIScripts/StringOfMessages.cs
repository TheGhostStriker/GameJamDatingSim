using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StringOfMessages : MonoBehaviour
{
    public string[] texts;
    public Text messageText;
    public int messageIndex = -1;
    // Start is called before the first frame update
    void Awake()
    {
        messageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNext();
        }
    }

    public void DisplayText(int index)
    {
        messageText.text = texts[index];
    }

    public void HideText()
    {
        messageText.text = "";
    }

    public void DisplayNext()
    {
        
        
            messageIndex = messageIndex  < texts.Length - 1 ? messageIndex + 1 : 0;
            DisplayText(messageIndex);
        
    }

    public void UpdateTexts(string [] texts)
    {
        this.texts = texts;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToNextDay : MonoBehaviour
{
    public int daysLeft = 0;
    public Text countDownText;
    public bool dateHappening = false;
    // Start is called before the first frame update
    void Start()
    {
        if (dateHappening) daysLeft = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(int days)
    {
        daysLeft -= days;
        UpdateText();
    }

    private void UpdateText()
    {
        countDownText.GetComponent<UnityEngine.UI.Text>().text = "DAYS LEFT: " + daysLeft;
        if(daysLeft == 0)
        {
            countDownText.GetComponent<UnityEngine.UI.Text>().text = "DATE NIGHT";
            dateHappening = true;
            if(dateHappening == true)
            {
                daysLeft = 8;
            }
        }
           
    }
}

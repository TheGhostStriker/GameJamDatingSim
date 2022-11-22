using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TurnHandler : MonoBehaviour
{
    public static bool firstDate = false;

    [SerializeField] Button[] buttons;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image circleImage;


    [SerializeField] List<Scene> dateScenes = new List<Scene>();

    int daysUntilDate = 5;
    int initialDaysUntilDate = 5;

    Scene nextScene;
   
    void Start()
    {
        foreach (Button b in buttons) b.enabled = true;

        daysUntilDate = initialDaysUntilDate;

        GenerateTexts();
    }

    void AdvanceDay()
    {
        daysUntilDate--;

        text.text = "Days Until Date: " + daysUntilDate;

        circleImage.fillAmount = 1f - (1f / initialDaysUntilDate * daysUntilDate);

        if (daysUntilDate == 0) StartDate();
    }

    void GenerateTexts()
    {
        if (firstDate)
        {
            int random = Random.Range(0, dateScenes.Count);

            nextScene = dateScenes[random];

            dateScenes.Remove(nextScene);


            // DO TEXTS
            
        }
    }
    
    void StartDate()
    {
        foreach (Button b in buttons) b.enabled = false;

        if (!firstDate)
        {
            SceneManager.LoadScene("Blake - Cafe");
        }
        else
        {
            SceneManager.LoadScene(nextScene.ToString());
        }

        
    }
}

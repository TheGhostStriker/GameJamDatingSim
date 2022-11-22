using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntelligenceBar : MonoBehaviour
{
    public Image intelligenceBarImage;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntelligenceBarUpdate()
    {
        intelligenceBarImage.fillAmount = Mathf.Clamp(player.intelligence / player.maxIntelligence, 0, 1f);
    }
}

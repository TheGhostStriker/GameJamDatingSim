using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntelligenceBar : MonoBehaviour
{
    public Image intelligenceBarImage;
    public Image strengthBarImage;
    public Image charismaBarImage;
    public Image moneyBarImage;
    public Image affectionBarImage;
    public Player player;
    

    public LeanTweenType updateTween;
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
        intelligenceBarImage.fillAmount = Mathf.Clamp(player.intelligence / player.maxIntelligence, 0.1f, 1f);

        LeanTween.value(intelligenceBarImage.fillAmount, intelligenceBarImage.fillAmount + 0.1f, 2f)
            .setOnUpdate((float val) => { intelligenceBarImage.fillAmount = val; })
            .setEase(updateTween);
    }

    public void CharismaBarUpdate()
    {
        charismaBarImage.fillAmount = Mathf.Clamp(player.charisma / player.maxCharisma, 0.1f, 1f);
        LeanTween.value(charismaBarImage.fillAmount, charismaBarImage.fillAmount + 0.1f, 2f)
            .setOnUpdate((float val) => { charismaBarImage.fillAmount = val; })
            .setEase(updateTween);
    }

    public void StrengthBarUpdate()
    {
        strengthBarImage.fillAmount = Mathf.Clamp(player.strength / player.maxStrength, 0.1f, 1f);
        LeanTween.value(strengthBarImage.fillAmount, strengthBarImage.fillAmount + 0.1f, 2f)
            .setOnUpdate((float val) => { strengthBarImage.fillAmount = val; })
            .setEase(updateTween);
    }

    public void MoneyBarUpdate()
    {
        moneyBarImage.fillAmount = Mathf.Clamp(player.money / player.maxMoney, 0.1f, 1f);
        LeanTween.value(moneyBarImage.fillAmount, moneyBarImage.fillAmount + 0.1f, 2f)
            .setOnUpdate((float val) => { moneyBarImage.fillAmount = val; })
            .setEase(updateTween);
    }

    public void AffectionBarUpdate()
    {
        affectionBarImage.fillAmount = Mathf.Clamp(player.affection / player.maxAffection, 0.1f, 1f);
        LeanTween.value(affectionBarImage.fillAmount, affectionBarImage.fillAmount + 0.1f, 2f)
            .setOnUpdate((float val) => { affectionBarImage.fillAmount = val; })
            .setEase(updateTween);

    }
}

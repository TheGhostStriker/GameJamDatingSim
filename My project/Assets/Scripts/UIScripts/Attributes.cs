using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    public static Attributes instance;

    public static int strength = 0;
    public static int intelligence = 0;
    public static int charisma = 0;
    public static int money = 0;

    [SerializeField] Image strengthBar;
    [SerializeField] Image intelligenceBar;
    [SerializeField] Image charismaBar;
    [SerializeField] Image moneyBar;

    private void Awake()
    {
        instance = this;
    }

    public static void IncreaseStrength()
    {
        strength++;

        strength = Mathf.Clamp(strength, 0, 5);

        LeanTween.value(instance.strengthBar.fillAmount, strength / 5f, 0.5f).setOnUpdate((float val) => { instance.strengthBar.fillAmount = val; }).setEase(LeanTweenType.easeInOutQuad);
    }

    public static void IncreaseIntelligence()
    {
        intelligence++;

        intelligence = Mathf.Clamp(intelligence, 0, 5);

        LeanTween.value(instance.intelligenceBar.fillAmount, strength / 5f, 0.5f).setOnUpdate((float val) => { instance.intelligenceBar.fillAmount = val; }).setEase(LeanTweenType.easeInOutQuad);
    }

    public static void IncreaseCharisma()
    {
        charisma++;

        charisma = Mathf.Clamp(charisma, 0, 5);

        LeanTween.value(instance.charismaBar.fillAmount, strength / 5f, 0.5f).setOnUpdate((float val) => { instance.charismaBar.fillAmount = val; }).setEase(LeanTweenType.easeInOutQuad);
    }

    public static void IncreaseMoney()
    {
        money++;

        money = Mathf.Clamp(money, 0, 5);

        LeanTween.value(instance.moneyBar.fillAmount, strength / 5f, 0.5f).setOnUpdate((float val) => { instance.moneyBar.fillAmount = val; }).setEase(LeanTweenType.easeInOutQuad);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionBar : MonoBehaviour
{
    public static AffectionBar instance;

    static float affectionAmount = 0.25f;
    [SerializeField] Image affectionBarImage;
    [SerializeField] Image affectionThresholdImage;
    [SerializeField] float affectionSpeed = 2f;
    [SerializeField] Color positiveAffectionColour;
    [SerializeField] Color negativeAffectionColour;

    public static bool positiveAffectionValue = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        affectionBarImage.fillAmount = affectionAmount;

        if (affectionAmount >= 0.5f) affectionThresholdImage.color = positiveAffectionColour;
        else affectionThresholdImage.color = negativeAffectionColour;

    }

    public static void AddAffection(float val)
    {
        affectionAmount += val;

        Mathf.Clamp(affectionAmount, 0, 1);

        LeanTween.value(instance.affectionBarImage.fillAmount, affectionAmount, instance.affectionSpeed).setOnUpdate((float val) => { instance.affectionBarImage.fillAmount = val; CheckEffectionStatus(); }).setEase(LeanTweenType.easeInOutQuad);
    }



    static void CheckEffectionStatus()
    {
        if (instance.affectionBarImage.fillAmount >= 0.5f && !positiveAffectionValue)
        {
            positiveAffectionValue = true;

            LeanTween.color(instance.affectionThresholdImage.rectTransform, instance.positiveAffectionColour, 0.4f);
        }
        
        if (instance.affectionBarImage.fillAmount < 0.5f && positiveAffectionValue)
        {
            positiveAffectionValue = false;

            LeanTween.color(instance.affectionThresholdImage.rectTransform, instance.negativeAffectionColour, 0.4f);
        }
    }
}

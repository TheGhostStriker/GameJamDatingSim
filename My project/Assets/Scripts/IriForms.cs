using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IriForms : MonoBehaviour
{
    public static int iriForm = 1;

    [SerializeField] GameObject formTwo;
    [SerializeField] GameObject formThree;
    [SerializeField] GameObject formThreeLegs;

    public static void AdvanceForm()
    {
        iriForm++;

        iriForm = Mathf.Clamp(iriForm, 1, 3);
    }

    private void Start()
    {
        if (iriForm == 2) formTwo.SetActive(true);

        if (iriForm == 3)
        {
            formTwo.SetActive(false);
            formThree.SetActive(true);
            formThreeLegs.SetActive(true);
        }
    }
}

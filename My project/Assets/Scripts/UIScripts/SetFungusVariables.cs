using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SetFungusVariables : MonoBehaviour
{
    [SerializeField] Flowchart flowChart;

    private void Awake()
    {
        flowChart.SetFloatVariable("STR", Attributes.strength);
        flowChart.SetFloatVariable("INT", Attributes.intelligence);
        flowChart.SetFloatVariable("CHA", Attributes.charisma);
        flowChart.SetFloatVariable("MONEY", Attributes.money);
    }
}

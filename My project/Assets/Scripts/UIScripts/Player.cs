using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float intelligence, maxIntelligence;
    public float strength, maxStrength;
    public float charisma, maxCharisma;
    public float money, maxMoney;
    public float affection, maxAffection;
    public IntelligenceBar intelligenceBar;
    public IntelligenceBar strengthBar;
    public IntelligenceBar charismaBar;
    public IntelligenceBar moneyBar;
    public IntelligenceBar affectionBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   

    public void AddIntelligence()
    {
        intelligence += Mathf.Min(Random.value, intelligence + 2);
        intelligenceBar.IntelligenceBarUpdate();
        
    }

    public void RemoveIntelligence()
    {
        intelligence -= Mathf.Min(Random.value, intelligence / 2);
        intelligenceBar.IntelligenceBarUpdate();
    }

    public void AddStrength()
    {
        strength += Mathf.Min(Random.value, strength + 2);
        strengthBar.StrengthBarUpdate();
    }

    public void RemoveStrength()
    {
        strength -= Mathf.Min(Random.value, strength / 2);
        strengthBar.StrengthBarUpdate();
    }

    public void AddCharisma()
    {
        charisma += Mathf.Min(Random.value, charisma + 2);
        charismaBar.CharismaBarUpdate();
    }

    public void RemoveCharisma()
    {
        charisma -= Mathf.Min(Random.value, charisma / 2);
        charismaBar.CharismaBarUpdate();
    }

    public void AddMoney()
    {
        money += Mathf.Min(Random.value, money + 2);
        moneyBar.MoneyBarUpdate();

    }

    public void RemoveMoney()
    {
        money -= Mathf.Min(Random.value, money / 2);
        moneyBar.MoneyBarUpdate();
    }

    public void AddAffection()
    {
        affection += Mathf.Min(Random.value, affection + 2);
        affectionBar.AffectionBarUpdate();
    }

    public void RemoveAffection()
    {
        affection -= Mathf.Min(Random.value, affection / 2);
        affectionBar.AffectionBarUpdate();
    }
    


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            AddIntelligence();
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            RemoveIntelligence();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AddStrength();
        }
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            RemoveStrength();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            AddCharisma();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            RemoveCharisma();
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            AddMoney();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            RemoveMoney();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            AddAffection();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            RemoveAffection();
        }
    }
}

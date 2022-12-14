using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public bool isAffectionEnough = false;
    public bool doesSheLoveMe = false;
    public bool doesSheHateMe = true;

    public GameObject shootyourShotButton;
    public GameObject failureButton;
    public GameObject guaranteedWaifuButton;
    // Start is called before the first frame update
    void Start()
    {
        failureButton.SetActive(true);
    }

   

    // Update is called once per frame


    public void AddIntelligence()
    {
        intelligence += 1;//Mathf.Min(Random.value, intelligence + 2);
        intelligenceBar.IntelligenceBarUpdate();
        
        
    }

    public void RemoveIntelligence()
    {
        intelligence -= 1; //Mathf.Min(Random.value, intelligence / 2);
        intelligenceBar.IntelligenceBarUpdate();
    }

    public void AddStrength()
    {
        strength += 1; //Mathf.Min(Random.value, strength + 2);
        strengthBar.StrengthBarUpdate();
    }

    public void RemoveStrength()
    {
        strength -= 1; //Mathf.Min(Random.value, strength / 2);
        strengthBar.StrengthBarUpdate();
    }

    public void AddCharisma()
    {
        charisma += 1; //Mathf.Min(Random.value, charisma + 2);
        charismaBar.CharismaBarUpdate();
    }

    public void RemoveCharisma()
    {
        charisma -= 1; //Mathf.Min(Random.value, charisma / 2);
        charismaBar.CharismaBarUpdate();
    }

    public void AddMoney()
    {
        money += 1;//Mathf.Min(Random.value, money + 2);
        moneyBar.MoneyBarUpdate();

    }

    public void RemoveMoney()
    {
        money -= 1; //Mathf.Min(Random.value, money / 2);
        moneyBar.MoneyBarUpdate();
    }

    public void AddAffection()
    {
        affection += 1;//Mathf.Min(Random.value, affection + 2);
        affectionBar.AffectionBarUpdate();

        if (affection >= 10)
        {
            isAffectionEnough = true;
            doesSheHateMe = false;
            doesSheLoveMe = false;
        }
        if(isAffectionEnough == true)
        {
            shootyourShotButton.SetActive(true);
            failureButton.SetActive(false);
            guaranteedWaifuButton.SetActive(false);
        }
        if(affection <= 5)
        {
            doesSheHateMe = true;
            doesSheLoveMe = false;
            isAffectionEnough = false;
        }
        if(affection >= 18)
        {
            doesSheHateMe = false;
            doesSheLoveMe = true;
            isAffectionEnough = false;
        }
        if(doesSheLoveMe == true)
        {
            shootyourShotButton.SetActive(false);
            guaranteedWaifuButton.SetActive(true);
            failureButton.SetActive(false);
        }
        if(doesSheHateMe == true)
        {
            shootyourShotButton.SetActive(false);
            guaranteedWaifuButton.SetActive(false);
            failureButton.SetActive(true);
        }
    }

    public void RemoveAffection()
    {
        affection -= 1;//Mathf.Min(1, affection / 2);
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
        if(intelligence >= 10)
        {
            intelligence = 10;
        }
        if(intelligence <= 1)
        {
            intelligence = 1;
        }
        if (charisma >= 10)
        {
            charisma = 10;
        }
        if (charisma <= 1)
        {
            charisma = 1;
        }
        if (strength >= 10)
        {
            strength = 10;
        }
        if (strength <= 1)
        {
           strength = 1;
        }
        if (money >= 10)
        {
           money = 10;
        }
        if (money <= 1)
        {
            money = 1;
        }
        if(affection >= 20)
        {
            affection = 20;
        }
        if(affection <= 1)
        {
            affection = 1;
        }
        



    }
}

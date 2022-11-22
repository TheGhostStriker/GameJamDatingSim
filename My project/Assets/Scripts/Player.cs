using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float intelligence, maxIntelligence;
    public IntelligenceBar intelligenceBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   

    public void AddIntelligence()
    {
        intelligence += Mathf.Min(Random.value, intelligence + 2);
        Debug.Log(intelligence);
        intelligenceBar.IntelligenceBarUpdate();
        
    }

    public void RemoveIntelligence()
    {
        intelligence -= Mathf.Min(Random.value, intelligence / 2);
        intelligenceBar.IntelligenceBarUpdate();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddIntelligence();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            RemoveIntelligence();
        }
    }
}

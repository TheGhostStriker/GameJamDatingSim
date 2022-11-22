using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComedyLineBacking : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color col = sr.color;
        col.a -= Time.deltaTime;
        sr.color = col;
    }

    public void Miss()
    {
        sr.color = Color.red;
    }
    public void Hit()
    {
        sr.color = Color.green;
    }
}

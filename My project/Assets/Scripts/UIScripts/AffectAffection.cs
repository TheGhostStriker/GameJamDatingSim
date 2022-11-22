using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectAffection : MonoBehaviour
{
    public void ChangeAffection(float val)
    {
        Debug.Log("TEST");

        AffectionBar.AddAffection(val);
    }
}

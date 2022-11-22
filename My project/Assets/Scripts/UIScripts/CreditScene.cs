using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditScene : MonoBehaviour
{
    public Text text1;
    public Text text2;
    //public GameObject text3;
    //public GameObject text4;
    //public GameObject text5;
    //public GameObject text6;

    public Animator textAnim1;
    public Animator textAnim2;
    //public Animator textAnim3;
    //public Animator textAnim4;
    //public Animator textAnim5;
    //public Animator textAnim6;

    public void Start()
    {
        
        textAnim1.SetBool("FadeText", true);
        Invoke("FadeText2", 5f);
    }

    public void FadeText2()
    {
        textAnim1.SetBool("FadeText", false);
        textAnim2.SetBool("FadeText", true);
        //Invoke("FadeText3", 5f);
        
    }


}

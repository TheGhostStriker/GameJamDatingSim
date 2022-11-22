using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMiniGame : MonoBehaviour
{
    [SerializeField] Image burger, bell;
    [SerializeField] Sprite[] burgerSprites, bellSprites;
    [SerializeField] int[] order;
    [SerializeField] int currentOrder;
    [SerializeField] Animator anim;
    bool burgerFinished;

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddToBurger(int num)
    {
        if (burgerFinished) return;
        if (order[currentOrder] == num)
        {
            currentOrder++;
            burger.sprite = burgerSprites[currentOrder];
        }
        else
        {
            ResetBurger();
        }

        if (currentOrder == burgerSprites.Length - 1)
        {
            burgerFinished = true;
        }
    }

    public void PressBell()
    {
        if (burgerFinished)
        {
            //Add Money
            StartCoroutine(BellDing());
            Invoke("ResetBurger", .5f);
            anim.Play("BurgerLower");
            burgerFinished = false;
            currentOrder = 0;
        }

        IEnumerator BellDing()
        {
            bell.sprite = bellSprites[1];
            yield return new WaitForSeconds(1f);
            bell.sprite = bellSprites[0];
        }
    }

    void ResetBurger()
    {
        burger.sprite = burgerSprites[0];
        currentOrder = 0;
    }
}

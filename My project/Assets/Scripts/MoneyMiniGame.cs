using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyMiniGame : MonoBehaviour
{
    bool active;
    [SerializeField] Image burger, bell;
    [SerializeField] Sprite[] burgerSprites, bellSprites;
    [SerializeField] int[] order;
    [SerializeField] int currentOrder;
    [SerializeField] Animator anim;
    [SerializeField] TMP_Text timerText;
    [SerializeField] float timer;
    [SerializeField] int score;
    [SerializeField] FadeOut fadeOut;
    bool burgerFinished;


    bool minigameFinished = false;

    void Start()
    {

    }

    void Update()
    {
        if (!active) return;
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 100);
        timerText.text = ((int)timer).ToString();


        if (timer == 0 && !minigameFinished)
        {
            OnFinish();
        }
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

    public void ActivateTimed()
    {
        Invoke("Activate", 1f);
    }

    void Activate()
    {
        active = true;
    }

    void OnFinish()
    {
        minigameFinished = true;

        Attributes.IncreaseMoney();

        if (score > 3)
        {
            
            timerText.text = $"{score}!";
        }
        fadeOut.StartFadeOut();
    }

    public void PressBell()
    {
        if (burgerFinished)
        {
            score++;
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

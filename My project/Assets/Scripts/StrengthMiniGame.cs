using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class StrengthMiniGame : MonoBehaviour
{
    readonly WaitForEndOfFrame wait = new WaitForEndOfFrame();
    bool isGhostFading, isGreenGhostFading, active = true;
    [SerializeField] UnityEvent onFinish;
    Attributes instance;
    [SerializeField] RectTransform movingBar, sweetSpot, ghostBar, greenGhostBar, brain;
    [SerializeField] Transform shot;
    [SerializeField] TrailRenderer shotTrail;
    [SerializeField] Transform[] sodokuNumbers;
    [SerializeField] ParticleSystem brainParticles, numberParticle;
    SpriteRenderer ghostBarSpriteRenderer, greenGhostBarSpriteRenderer;
    readonly float spriteHalfSize = .15f;
    readonly float barEndHalfSize = .1f;
    Vector2 barStartPos;
    [SerializeField] float barDistanceMove, barSpeed;
    float distanceMoveCalc;
    float sweetSpotLocation, sweetSpotDistance;
    Vector2 sweetSpotBounds; //Top Bottom
    [SerializeField] int comboCurrent, comboMax;
    [SerializeField] float ghostFadeOutSpeed = 1, currentTime;
    [SerializeField] CameraShake shake;
    float accelerationTarget, accelerationCurrent, accelerationBuildUpSpeed = .1f, accelerationAddition = .1f;
    [SerializeField] TextMeshPro timer, score, levelUp;



    // Start is called before the first frame update
    void Start()
    {
        ghostBarSpriteRenderer = ghostBar.GetComponent<SpriteRenderer>();
        greenGhostBarSpriteRenderer = greenGhostBar.GetComponent<SpriteRenderer>();
        barStartPos = movingBar.position;
        distanceMoveCalc = barDistanceMove - (spriteHalfSize + barEndHalfSize);
        GenerateNewSweetSpot();
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        accelerationCurrent = Mathf.MoveTowards(accelerationCurrent, accelerationTarget, accelerationBuildUpSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.O)) GenerateNewSweetSpot();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsInSweetSpot())
            {
                HitSweetSpot();
            }
            else
            {
                MissSweetSpot();
            }

        }

        movingBar.position = barStartPos + (distanceMoveCalc * Mathf.Sin(Time.time * (barSpeed + accelerationCurrent)) * Vector2.down);
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, 10);
        timer.text = Mathf.CeilToInt(currentTime).ToString();
        if (currentTime < 2) timer.color = Color.red;
        if (currentTime == 0) Complete();
    }

    void GenerateNewSweetSpot()
    {
        sweetSpotDistance = 3 - ((float)comboCurrent / comboMax) * 2;
        float locBound = barDistanceMove - (sweetSpotDistance * .5f);
        sweetSpotLocation = Random.Range(-locBound, locBound);
        sweetSpotBounds = new Vector2(sweetSpotLocation + (sweetSpotDistance * .5f), sweetSpotLocation + (sweetSpotDistance * -.5f));
        sweetSpot.position = new Vector2(movingBar.position.x, sweetSpotLocation);
        sweetSpot.localScale = new Vector2(1, sweetSpotDistance);
        brain.position = sweetSpot.position;
    }

    void HitSweetSpot()
    {
        greenGhostBar.position = movingBar.position;
        sodokuNumbers[comboCurrent].gameObject.SetActive(true);
        numberParticle.transform.position = sodokuNumbers[comboCurrent].position;
        numberParticle.Play();
        shotTrail.enabled = false;
        shot.position = movingBar.position;
        shotTrail.enabled = true;
        shot.GetComponent<ShotTrail>().target = sodokuNumbers[comboCurrent].position;
        comboCurrent++;
        comboCurrent = Mathf.Clamp(comboCurrent, 0, comboMax);
        GenerateNewSweetSpot();
        accelerationTarget += accelerationAddition;
        brainParticles.Play();
        shake.Shake(.1f, .25f);



        Color t = greenGhostBarSpriteRenderer.color;
        t.a = 1;
        greenGhostBarSpriteRenderer.color = t;

        if (!isGreenGhostFading)
            StartCoroutine(FadeGhost());

        IEnumerator FadeGhost()
        {
            isGreenGhostFading = true;
            while (t.a > 0)
            {
                t.a -= Time.deltaTime * ghostFadeOutSpeed;
                greenGhostBarSpriteRenderer.color = t;

                yield return wait;
            }
            isGreenGhostFading = false;
        }
        if (comboCurrent == comboMax) Complete();
    }

    void Complete()
    {
        score.gameObject.SetActive(true);
        score.text = $"{comboCurrent}/9";

        if (comboCurrent >= 7)
        {
            levelUp.gameObject.SetActive(true);
            Attributes.IncreaseIntelligence();
        }


        active = false;
        if (onFinish != null) onFinish.Invoke();
    }

    void MissSweetSpot()
    {
        comboCurrent = 0;
        ghostBar.position = movingBar.position;
        Color t = ghostBarSpriteRenderer.color;
        t.a = 1;
        ghostBarSpriteRenderer.color = t;

        for (int i = 0; i < sodokuNumbers.Length; i++)
        {
            sodokuNumbers[i].gameObject.SetActive(false);
        }

        if (!isGhostFading)
            StartCoroutine(FadeGhost());

        IEnumerator FadeGhost()
        {
            isGhostFading = true;
            while (t.a > 0)
            {
                t.a -= Time.deltaTime * ghostFadeOutSpeed;
                ghostBarSpriteRenderer.color = t;

                yield return wait;
            }
            isGhostFading = false;
        }
        GenerateNewSweetSpot();
        accelerationTarget = 0;
    }

    public void TimedActivate()
    {
        Invoke("Activate", 1);
    }

    public void Activate()
    {
        active = true;
    }

    bool IsInSweetSpot()
    {
        float y = movingBar.position.y;
        return (y < sweetSpotBounds.x && y > sweetSpotBounds.y);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(movingBar.position, movingBar.position + (distanceMove * Vector3.up));
    }

}

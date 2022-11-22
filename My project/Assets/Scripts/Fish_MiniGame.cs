using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fish_MiniGame : MonoBehaviour
{
    [SerializeField] private UnityEvent <float> GameCompleate;

    [SerializeField] private float _playTime;
    [SerializeField] private float _FillTime;

    [SerializeField] private float _onScreenDistance;
    [SerializeField] private float _onScreenTargetSize;

    [SerializeField] private Transform _MarkerObjectTransfrom;
    [SerializeField] private Transform _TargetAreaTransfrom;
    [SerializeField] private Transform _ScoreBar;


    [SerializeField] private float _targetWidth;
    [SerializeField] private float _targetMovementSpeed;
    [SerializeField] private float _timeBetweenSettingNewTargetPosition;

    [SerializeField] private float _decayAccelerationCoefficient;
    [SerializeField] private float _decayLastClickTimeEffectCoefficient;
    [SerializeField] private float _randomAddValueRangeCoefficent;

    [SerializeField] private bool started;
    [SerializeField] private bool gameEnded;

    float timeLastClicked;
    float timetillTargetUpdated = 0;
    float MAXplayerPosition = 1000;
    float playerPosition;
    float targetPosition;
    float newTargetPosition;
    float endTimerTime;
    float timeOverTarget; 
    float normalisedScore;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        timeOverTarget = 0f;
    }
    void Update()
    {
        //Marker Position
        PlayerValueDecay();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            //Input.GetMouseButtonDown(0))
        {
            MouseClicked(); 
            StartScoring();
        }
        UpdatePlayerPosition();
        
        //Target Position
        SetNewTargetPosition();
        UpdateTargetPosition();
        CheckIfPlayerOverTarget();

        //Scoring
        CheckForEndofGameTimer();

    }
    private void LateUpdate()
    {
        NormalisedFillBar();
        UpdateScoreBar();
    }

    private void StartScoring()
    {
        if (started) return;
        started = true;
        gameEnded = false;
        timeOverTarget = 0;
        endTimerTime = Time.time + _playTime;
    }

    private void CheckForEndofGameTimer()
    {
        if (endTimerTime > Time.time) return;
        gameEnded = true;
        GameCompleate?.Invoke(normalisedScore);
    }


    private void PlayerValueDecay()
    {
        if (playerPosition < 0f) return;
        playerPosition -= Time.deltaTime * _decayAccelerationCoefficient *  ((Time.time - timeLastClicked) * _decayLastClickTimeEffectCoefficient);
    }

    private void MouseClicked()
    {
        timeLastClicked = Time.time;
        AddToPlayerValue();
    }

    private void AddToPlayerValue()
    {
        playerPosition = Mathf.Clamp(playerPosition += Random.Range((_randomAddValueRangeCoefficent / 3), _randomAddValueRangeCoefficent), 0f, MAXplayerPosition);
    }

    private void UpdatePlayerPosition()
    {
        _MarkerObjectTransfrom.position = new Vector2(0, this.transform.position.y + Mathf.Lerp(0, _onScreenDistance, (playerPosition / MAXplayerPosition)));
    }

    private void UpdateTargetPosition()
    {
        UpdateTargetValue();
        _TargetAreaTransfrom.position = new Vector2(0, this.transform.position.y + Mathf.Lerp(0, _onScreenDistance, (targetPosition / MAXplayerPosition)));
        Debug.Log("current targetPosition: [" + targetPosition + "]; new Target Y Value: [" + newTargetPosition + "]" );
    }
    private void UpdateTargetValue()
    {
        targetPosition = newTargetPosition > targetPosition ? (targetPosition + Time.deltaTime * _targetMovementSpeed) : (targetPosition - Time.deltaTime * _targetMovementSpeed);
    }

    private void SetNewTargetPosition()
    {
        if (timetillTargetUpdated > Time.time) return;

        // set new wait time
        timetillTargetUpdated = Time.time + _timeBetweenSettingNewTargetPosition;

        //set new target position
        float halfOfTargetWith = _onScreenTargetSize*100 / 2;
        newTargetPosition = halfOfTargetWith;
        newTargetPosition =  Mathf.Clamp( Random.Range(halfOfTargetWith, MAXplayerPosition - halfOfTargetWith),0,MAXplayerPosition);
    }

    private void CheckIfPlayerOverTarget()
    {
        float temp =  Mathf.Sqrt( (targetPosition - playerPosition) * (targetPosition - playerPosition) );

        if ( Mathf.Sqrt((targetPosition - playerPosition) * (targetPosition - playerPosition)) < _targetWidth)
        {
            _TargetAreaTransfrom.GetComponent<SpriteRenderer>().color = Color.green;
            ScoreWhileOverTarget();
        }
        else
        {
            _TargetAreaTransfrom.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    } 
    
    private void ScoreWhileOverTarget()
    {
        if (!gameEnded && started) timeOverTarget += Time.deltaTime ;
    }

    private void NormalisedFillBar()
    {
        normalisedScore = Mathf.Lerp(0, 1, timeOverTarget / _FillTime);
    }

    private void UpdateScoreBar()
    {
        _ScoreBar.localScale = new Vector3(1, normalisedScore);
    }


}

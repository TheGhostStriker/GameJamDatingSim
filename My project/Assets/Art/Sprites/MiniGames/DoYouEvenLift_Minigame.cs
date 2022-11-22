using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoYouEvenLift_Minigame : MonoBehaviour
{
    float playerPosition;
    float targetBoxPosition;

    float MAXPosition;

    float maxRangeToAddOnClick = 50f;

    float timeWhenLastClicked;
    float accelerationCoEfficient = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) MouseClicked();
        if (playerPosition > 0) MovePlayerPositionDown();
    }

    private void MouseClicked()
    {
        ResetTimeSinceLastClick();
    }

    void ResetTimeSinceLastClick()
    {
        timeWhenLastClicked = Time.time;
    }

    void AddToPlayerValue()
    {
        playerPosition = Mathf.Clamp(playerPosition += Random.Range(0,maxRangeToAddOnClick), 0f, 1000f);
    }

    void MovePlayerPositionDown()
    {
        playerPosition -= accelerationCoEfficient * Time.deltaTime * (Time.time - timeWhenLastClicked);
    }





}

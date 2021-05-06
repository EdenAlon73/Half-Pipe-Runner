using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private GameObject scoreText;
    private LeftBall leftBallScrip;
    private RightBall rightBallScript;
    private float currentTime;
    private float startingTime = 2f;
    
    private void Start()
    {
        currentTime = startingTime;
        leftBallScrip = FindObjectOfType<LeftBall>();
        rightBallScript = FindObjectOfType<RightBall>();
    }

    private void Update()
    {
      // CantMoveCountdown();
    }

    private void CantMoveCountdown()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0f;
            leftBallScrip.canMove = true;
            rightBallScript.canMove = true;
            scoreText.SetActive(true);
            countdownText.enabled = false;
        }
        else
        {
            leftBallScrip.canMove = false;
            rightBallScript.canMove = false;
            scoreText.SetActive(false);
        }
    }
}

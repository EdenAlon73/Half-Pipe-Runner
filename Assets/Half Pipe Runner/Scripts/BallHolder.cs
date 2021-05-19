using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : MonoBehaviour
{
    public bool bothFinished = false;
    private LeftBall leftBallScript;
    private RightBall rightBallScript;
    
    [Header("Tween Move Config")]
    public Vector3 desiredPosRight;
    public Vector3 desiredPosLeft;
    public float jumpPower;
    public float ogJumpPower;
    public float durationOfTween;
    public bool snapping = false;
    public int numOfJumps = 0;
    private float ballsYValue;
    private float rightBallsXValue;
    private float leftBallsXValue;

    public GameObject confettiFX;
    public GameObject confettiFX2;
    [SerializeField] private Animator leftBallAnimator;
    [SerializeField] private Animator rightBallAnimator;
    [SerializeField] private bool needsAnimator = false;
    private void Start()
    {
        leftBallScript = GetComponentInChildren<LeftBall>();
        rightBallScript = GetComponentInChildren<RightBall>();
        ogJumpPower = jumpPower;
    }

    private void Update()
    {
        if(rightBallScript.finishedMoving && leftBallScript.finishedMoving)
        {
            bothFinished = true;
        }
        else
        {
            bothFinished = false;
        }
        UpdateJumpPower();
        if (needsAnimator)
        {
            UpdateBallAnimator();
        }
    }

    private void UpdateJumpPower()
    {
        if (leftBallScript != null)
        {
            ballsYValue = leftBallScript.transform.localPosition.y;
            jumpPower = ballsYValue + 1f;// was -1.95f
        }
        if(ballsYValue > ogJumpPower)
        {
            jumpPower = ogJumpPower;
        }
    }
    private void UpdateBallAnimator()
    {
        
        rightBallsXValue = rightBallScript.transform.localPosition.x;
        leftBallsXValue = leftBallScript.transform.localPosition.x;
        leftBallAnimator.SetFloat("Yvalue", ballsYValue);
        leftBallAnimator.SetFloat("Xvalue", leftBallsXValue);
        rightBallAnimator.SetFloat("Yvalue", ballsYValue);
        rightBallAnimator.SetFloat("Xvalue", rightBallsXValue);
        if (rightBallsXValue > 0)
        {
            rightBallAnimator.SetBool("OnLeftSide", false);
        }
        if (rightBallsXValue < 0)
        {
            rightBallAnimator.SetBool("OnLeftSide", true);
        }
        if(leftBallsXValue > 0)
        {
            leftBallAnimator.SetBool("OnLeftSide", false);
        }
        if (leftBallsXValue < 0)
        {
            leftBallAnimator.SetBool("OnLeftSide", true);
        }
       
        
    }
}

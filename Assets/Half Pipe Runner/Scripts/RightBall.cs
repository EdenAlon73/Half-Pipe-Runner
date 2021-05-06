using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class RightBall : MonoBehaviour
{
    //Cache Referance:
    private Touch touch;
    private LeftBall leftBallScript;
    private BallHolder ballHolder;
    [SerializeField] private GameObject leftBallObj;
    
    //Tween Movement Conditions
    public bool finishedMoving = false;
    private bool inMidTrigger = false;
    private float xValue;
    private float yValue;
    
    //Win\Lose Conditions
    public bool isLoseRightBall = false;
    public bool isWinRightBall = false;
    public bool canMove = true;
    

    private void Start()
    {
        leftBallScript = FindObjectOfType<LeftBall>();
        ballHolder = GetComponentInParent<BallHolder>();
        finishedMoving = true;
        inMidTrigger = false;
    }

    private void Update()
    {
        if (canMove)
        {
            Movement();  
        }
        //  MoveCheck();
    }

    private void Movement()
    {
        xValue = transform.position.x;
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (leftBallObj.transform.localPosition.x < transform.localPosition.x && touch.phase == TouchPhase.Began)
            {
                //Move Left
                transform.DOLocalJump(ballHolder.desiredPosLeft, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
            }
            
            if (leftBallObj.transform.localPosition.x > transform.localPosition.x && touch.phase == TouchPhase.Began)
            {
                //Move Right
                transform.DOLocalJump(ballHolder.desiredPosRight, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (leftBallObj.transform.localPosition.x < transform.localPosition.x)
            {
                transform.DOLocalJump(ballHolder.desiredPosLeft, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
                print("leftball perform left");
            }

            else
            {
                transform.DOLocalJump(ballHolder.desiredPosRight, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
                print("leftball perform right");
            }
        }
        
    }
 
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Handheld.Vibrate();
            isLoseRightBall = true;
            Destroy(gameObject);
            Destroy(leftBallObj);
        }
        if (other.gameObject.CompareTag("WinTrigger"))
        {
            canMove = false;
        }
        
        
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class LeftBall : MonoBehaviour
{
    
    //Cache Referance:
    private Touch touch;
    private RightBall rightBallScript;
    private BallHolder ballHolder;
    [SerializeField] private GameObject rightBallObj;
    
    //Tween Movement Conditions
    public bool finishedMoving = false;
    private bool inMidTrigger = false;
    private float xValue;
    private float yValue;
    
    //Win\Lose Conditions
    public bool isLoseLeftBall = false;
    public bool isWinLeftBall = false;
    public bool canMove = true;
   
    
    private void Start()
    {
        rightBallScript = FindObjectOfType<RightBall>();
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
        
    }

    private void Movement()
    {
        xValue = transform.position.x;
        
        if (Input.touchCount > 0 )
        {
            touch = Input.GetTouch(0);
            if (rightBallObj.transform.localPosition.x < transform.localPosition.x && touch.phase == TouchPhase.Began)
            {
                //Move Left
                transform.DOLocalJump(ballHolder.desiredPosLeft, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
            }
            
            if (rightBallObj.transform.localPosition.x > transform.localPosition.x && touch.phase == TouchPhase.Began)
            {
                //Move Right
                transform.DOLocalJump(ballHolder.desiredPosRight, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rightBallObj.transform.localPosition.x < transform.localPosition.x)
            {
                //Move Left
                transform.DOLocalJump(ballHolder.desiredPosLeft, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
            }

            else
            {
                //Move Right
                transform.DOLocalJump(ballHolder.desiredPosRight, -ballHolder.jumpPower, ballHolder.numOfJumps,
                    ballHolder.durationOfTween, ballHolder.snapping);
            }
        }
    }
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Handheld.Vibrate();
            isLoseLeftBall = true;
            Destroy(gameObject);
            Destroy(rightBallObj);
        }

        if (other.gameObject.CompareTag("WinTrigger"))
        {
            ballHolder.confettiFX.SetActive(true);
            ballHolder.confettiFX2.SetActive(true);
            Invoke("OpenWinCanvas", 1f);
            canMove = false;
        }
        
    }

    private void OpenWinCanvas()
    {
        isWinLeftBall = true;
    }
   

}



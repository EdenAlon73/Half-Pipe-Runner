using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{
    /*
    [Header("SFX")]
    [SerializeField] private AudioClip[] xSounds;
    private AudioSource myAudioSource;
    
    [Header("Combo Images")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float endPosYOne;
    [SerializeField] private float endPosYTwo;
    [SerializeField] private Sprite[] comboImages;
    [SerializeField] private GameObject comboImagesUI;
    private Image _image;
    private Sequence _sequence;
    
    [SerializeField] private int pointsPerZigzag = 1;
    
    */
    private GameSession myGameSession;
    //new
    GameManager gameManager;
    [SerializeField] private Transform scoreSpwanPoint;
    [SerializeField] private GameObject scoreTxt;
    [SerializeField] private Canvas canvas;
    private Animator anim;
    [SerializeField] private ParticleSystem ballsTouchingFX;
    
    
    private void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        //myAudioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightBall"))
        {
           // Handheld.Vibrate(); maybe???
            FindObjectOfType<GameSession>().AddToScore(pointsPerZigzag);
            AudioClip clip = xSounds[UnityEngine.Random.Range(0, xSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            
            if ((myGameSession.currentScore % 5 == 0 && myGameSession.currentScore != 0 ))
            {
                
               _sequence = DOTween.Sequence().SetAutoKill(false);
               _sequence.Append(_rectTransform.DOLocalMoveY(endPosYOne, 0.5f, false).SetEase(Ease.Linear).SetEase(Ease.InOutBack));
               Invoke("EaseOut", 2);
               comboImagesUI.GetComponent<Image>().sprite = comboImages[UnityEngine.Random.Range(0, comboImages.Length)];

            }
            

        }
    }
   
    private void EaseOut()
    {
        _sequence.Append(_rectTransform.DOLocalMoveY(endPosYTwo, 1f, false).SetEase(Ease.Linear));
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightBall"))
        {
            gameManager.AddToScore();
            // Instantiate(scoreTxt, scoreSpwanPoint.position, Quaternion.identity, canvas.transform);   For little points jumping near balls
            ballsTouchingFX.Play();
        }
    }
}

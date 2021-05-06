using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UICombos : MonoBehaviour
{
    
    [SerializeField] private Sprite[] comboImages;
    
    
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float endScale;
    [SerializeField] private float endPosX;
    
    private GameSession myGameSession;
    private Image _image;

    private void Start()
    {
        _image = this.GetComponent<Image>();
        myGameSession = FindObjectOfType<GameSession>();
    }
    
}

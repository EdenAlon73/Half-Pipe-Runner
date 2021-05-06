using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private GameSession myGameSession;
    
    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        myGameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        scoreText.text = myGameSession.GetScore().ToString();
    }
}

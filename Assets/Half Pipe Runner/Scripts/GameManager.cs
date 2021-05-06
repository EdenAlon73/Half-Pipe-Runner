using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentScore = 0;
    [SerializeField] private int pointsPerCross = 10;
    [SerializeField] private TextMeshProUGUI[] scoreTexts;
    [SerializeField] private TextMeshProUGUI ingameScoreText;
    private void Awake()
    {
        currentScore = 0;
        pointsPerCross = 10;

    }
    private void Start()
    {
        foreach (var textBox in scoreTexts)
        {
            textBox.text = currentScore.ToString();
        }
    }
    public void AddToScore()
    {
        currentScore = currentScore + pointsPerCross;
        
        foreach (var textBox in scoreTexts)
        {
            textBox.text = currentScore.ToString();
        }
        StartCoroutine(ScorePulse());
    }
    

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private IEnumerator ScorePulse()
    {
        for (float i = 1f; i <= 1.4f; i += 0.05f)
        {
            ingameScoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        ingameScoreText.rectTransform.localScale = new Vector3(1.4f, 1.4f, 1.4f);

        for (float i = 1.4f; i >= 1f; i -= 0.05f)
        {
            ingameScoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        ingameScoreText.rectTransform.localScale = new Vector3(1, 1, 1);

    }
}

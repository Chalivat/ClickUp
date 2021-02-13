using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;

    public float time;
    private bool isPlaying;

    void Start()
    {
        UpdateScore(score);
    }

    void UpdateScore(float value)
    {
        scoreText.text = value.ToString() + "/20";
    }

    public void Go()
    {
        isPlaying = true;
    }

    public void Timer()
    {
        time -= Time.deltaTime;
        UpdateScore((int)time);
        
    }

    void Update()
    {
        Timer();
    }
}

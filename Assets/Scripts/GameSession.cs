﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.5f, 2f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text =  currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() 
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}

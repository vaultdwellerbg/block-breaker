﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.5f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesCountText;
    [SerializeField] int currentScore = 0;
    [SerializeField] int lives = 2;
    [SerializeField] bool enableAutoPlay = false;

    [Header("Speedup Settings")]
    [SerializeField] bool enableSpeedup = true;
    [SerializeField] int pointsToRaiseSpeed = 25;
    [Range(0.0f, 1f)] [SerializeField] float speedRaise = 0.1f;

    float initialGameSpeed;

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
        livesCountText.text = lives.ToString();
        initialGameSpeed = gameSpeed;
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (initialGameSpeed != 0f)
        {
            ResetGameSpeed();
        }    
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();

        if (enableSpeedup)
        {
            AdjustGameSpeed();
        }
    }

    public void TakeLife()
    {
        lives--;
        livesCountText.text = lives.ToString();
    }

    public bool AreLivesLeft()
    {
        return lives > 0;
    }

    public bool IsAutoPlayEnabled()
    {
        return enableAutoPlay;
    }

    private void AdjustGameSpeed()
    {
        if (currentScore % pointsToRaiseSpeed == 0)
        {
            gameSpeed += speedRaise;
        }
    }

    private void ResetGameSpeed()
    {
        gameSpeed = initialGameSpeed;
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}

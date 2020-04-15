using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.5f, 2f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int currentScore = 0;

    [Header("Speedup Settings")]
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
        initialGameSpeed = gameSpeed;
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    private void OnLevelWasLoaded(int level)
    {
        ResetGameSpeed();
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();

        AdjustGameSpeed();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    [Range(0.5f, 2f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int currentScore = 0;

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
}

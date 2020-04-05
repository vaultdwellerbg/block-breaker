using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.5f, 2f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 5;

    [SerializeField] int currentScore = 0;

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() 
    {
        currentScore += pointsPerBlock;
    }
}

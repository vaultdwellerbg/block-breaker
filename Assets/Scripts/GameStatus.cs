using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.5f, 2f)] [SerializeField] float gameSpeed = 1f;

    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}

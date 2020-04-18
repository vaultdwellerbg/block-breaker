using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
	[SerializeField] Ball ball;

	GameSession gameSession;
	SceneLoader sceneLoader;

	private void Start()
	{
		gameSession = FindObjectOfType<GameSession>();
		sceneLoader = FindObjectOfType<SceneLoader>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gameSession.TakeLife();

		if (gameSession.AreLivesLeft())
		{
			ball.ResetBall();
		}
		else
		{
			SceneManager.LoadScene("GameOver");
		}
	}
}

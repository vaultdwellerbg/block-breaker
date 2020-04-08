using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] AudioClip destroySound;

	Level level;
	GameSession gameSession;

	private void Start()
	{
		level = FindObjectOfType<Level>();
		level.CountBreakableBlocks();
		gameSession = FindObjectOfType<GameSession>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		DestroyBlock();
	}

	private void DestroyBlock()
	{
		level.BlockDestroyed();
		gameSession.AddToScore();
		AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	const string BREAKABLE = "Breakable";

	[SerializeField] AudioClip destroySound;
	[SerializeField] GameObject destroyVFXPrefab;

	Level level;
	GameSession gameSession;

	private void Start()
	{
		gameSession = FindObjectOfType<GameSession>();
		level = FindObjectOfType<Level>();
		CountBreakableBlocks();
	}

	private void CountBreakableBlocks()
	{
		if (tag == BREAKABLE)
		{
			level.CountBlocks();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (tag == BREAKABLE)
		{
			DestroyBlock();
		}
	}

	private void DestroyBlock()
	{
		level.BlockDestroyed();
		gameSession.AddToScore();
		AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
		Destroy(gameObject);
		TriggerDestroyVFX();
	}

	private void TriggerDestroyVFX()
	{
		GameObject destroyVFX = Instantiate(destroyVFXPrefab, transform.position, transform.rotation);
		Destroy(destroyVFX, 1f);
	}
}
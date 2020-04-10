using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] AudioClip destroySound;
	[SerializeField] GameObject destroyVFXPrefab;

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
		TriggerDestroyVFX();
	}

	private void TriggerDestroyVFX()
	{
		GameObject destroyVFX = Instantiate(destroyVFXPrefab, transform.position, transform.rotation);
		Destroy(destroyVFX, 1f);
	}
}